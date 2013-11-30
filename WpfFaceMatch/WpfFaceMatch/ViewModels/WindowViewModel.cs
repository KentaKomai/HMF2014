﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Livet;
using WpfFaceMatch.Views;

namespace WpfFaceMatch.ViewModels
{
	internal class WindowViewModel : ViewModel
	{
		#region Title 変更通知プロパティ

		private string _Title;

		public string Title
		{
			get { return this._Title; }
			set
			{
				if (this._Title != value)
				{
					this._Title = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region WindowState 変更通知プロパティ

		private WindowState _WindowState;

		public WindowState WindowState
		{
			get { return this._WindowState; }
			set
			{
				if (this._WindowState != value)
				{
					this._WindowState = value;
					this.IsMaximized = value == WindowState.Maximized;
					this.CanNormalize = value == WindowState.Maximized;
					this.CanMaximize = value == WindowState.Normal;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region IsMaximized 変更通知プロパティ

		private bool _IsMaximized;

		public bool IsMaximized
		{
			get { return this._IsMaximized; }
			set
			{
				if (this._IsMaximized != value)
				{
					this._IsMaximized = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanMaximize 変更通知プロパティ

		private bool _CanMaximize = true;

		public bool CanMaximize
		{
			get { return this._CanMaximize; }
			set
			{
				if (this._CanMaximize != value)
				{
					this._CanMaximize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanMinimize 変更通知プロパティ

		private bool _CanMinimize = true;

		public bool CanMinimize
		{
			get { return this._CanMinimize; }
			set
			{
				if (this._CanMinimize != value)
				{
					this._CanMinimize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region CanNormalize 変更通知プロパティ

		private bool _CanNormalize = false;

		public bool CanNormalize
		{
			get { return this._CanNormalize; }
			set
			{
				if (this._CanNormalize != value)
				{
					this._CanNormalize = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		public WindowViewModel()
		{
			this.Title = "u-Comm Client";
		}

		public void ChangePurple()
		{
			App.Current.ThemeService.Change(Accent.Purple);
		}

		public void ChangeBlue()
		{
			App.Current.ThemeService.Change(Accent.Blue);
		}

		public void ChangeOrange()
		{
			App.Current.ThemeService.Change(Accent.Orange);
		}
	}
}
