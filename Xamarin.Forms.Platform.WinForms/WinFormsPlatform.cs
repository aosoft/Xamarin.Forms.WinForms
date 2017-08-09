using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WinFormsPlatform : IPlatform, INavigation, IDisposable
	{
		Rectangle _bounds;
		readonly Form _container;
		Page _currentPage;
		readonly NavigationModel _navModel = new NavigationModel();

		#region Constructor / Dispose

		internal WinFormsPlatform(Form container)
		{
			_container = container;
		}

		public void Dispose()
		{
		}

		#endregion

		internal static readonly BindableProperty RendererProperty = BindableProperty.CreateAttached("Renderer",
			typeof(IVisualElementRenderer), typeof(WinFormsPlatform), default(IVisualElementRenderer));

		public static IVisualElementRenderer GetRenderer(VisualElement element)
		{
			return (IVisualElementRenderer)element.GetValue(RendererProperty);
		}

		public static void SetRenderer(VisualElement element, IVisualElementRenderer value)
		{
			element.SetValue(RendererProperty, value);
			element.IsPlatformEnabled = value != null;
		}

		public static IVisualElementRenderer CreateRenderer(VisualElement element)
		{
			if (element == null)
				throw new ArgumentNullException(nameof(element));

			IVisualElementRenderer renderer = Registrar.Registered.GetHandler<IVisualElementRenderer>(element.GetType()) ??
											  new DefaultRenderer();
			renderer.SetElement(element);
			return renderer;
		}

		internal void SetPage(Page newRoot)
		{
			if (newRoot == null)
				throw new ArgumentNullException(nameof(newRoot));

			_navModel.Clear();

			_navModel.Push(newRoot, null);
			SetCurrent(newRoot, true);
			Application.Current.NavigationProxy.Inner = this;
		}

		/*async*/ void SetCurrent(Page newPage, bool popping = false, Action completedCallback = null)
		{
			if (newPage == _currentPage)
				return;

			newPage.Platform = this;

			if (_currentPage != null)
			{
				Page previousPage = _currentPage;
				IVisualElementRenderer previousRenderer = GetRenderer(previousPage);
				_container.Controls.Remove(previousRenderer.ContainerElement);

				if (popping)
					previousPage.Cleanup();
			}

			newPage.Layout(ContainerBounds);

			IVisualElementRenderer pageRenderer = newPage.GetOrCreateRenderer();
			_container.Controls.Add(pageRenderer.ContainerElement);

			pageRenderer.ContainerElement.Width = _container.Width;
			pageRenderer.ContainerElement.Height = _container.Height;

			completedCallback?.Invoke();

			_currentPage = newPage;

			//UpdateToolbarTracker();
			//await UpdateToolbarItems();
		}

		internal virtual Rectangle ContainerBounds
		{
			get { return _bounds; }
		}

		internal void UpdatePageSizes()
		{
			Rectangle bounds = ContainerBounds;
			if (bounds.IsEmpty)
				return;
			foreach (Page root in _navModel.Roots)
			{
				root.Layout(bounds);
				IVisualElementRenderer renderer = GetRenderer(root);
				if (renderer != null)
				{
					renderer.ContainerElement.Width = _container.Width;
					renderer.ContainerElement.Height = _container.Height;
				}
			}
		}

		#region IPlatform

		public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region INavigation

		public IReadOnlyList<Page> ModalStack
        {
            get
            {
				return _navModel.Tree.Last();
			}
        }

		public IReadOnlyList<Page> NavigationStack
        {
            get
            {
				return _navModel.Modals.ToList();
			}
        }

		public void InsertPageBefore(Page page, Page before)
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopModalAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopModalAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PopToRootAsync()
		{
			throw new NotImplementedException();
		}

		public Task PopToRootAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PushAsync(Page page)
		{
			throw new NotImplementedException();
		}

		public Task PushAsync(Page page, bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PushModalAsync(Page page)
		{
			if (page == null)
				throw new ArgumentNullException(nameof(page));

			var tcs = new TaskCompletionSource<bool>();
			_navModel.PushModal(page);
			//SetCurrent(page, completedCallback: () => tcs.SetResult(true));
			return tcs.Task;
		}

		public Task PushModalAsync(Page page, bool animated)
		{
			var tcs = new TaskCompletionSource<Page>();
			Page result = _navModel.PopModal();
			//SetCurrent(_navModel.CurrentPage, true, () => tcs.SetResult(result));
			return tcs.Task;
		}

		public void RemovePage(Page page)
		{
			throw new NotImplementedException();
		}

		#endregion


	}
}
