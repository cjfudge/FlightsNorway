using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

using FlightsNorway.Lib.Model;
using FlightsNorway.Lib.Messages;
using FlightsNorway.Lib.ViewModels;

using TinyIoC;
using TinyMessenger;

namespace FlightsNorway.Tables
{
	public class AirportsTableViewController : UITableViewController
	{	
		private readonly AirportsDataSource _dataSource;
		
		public AirportsTableViewController(AirportsDataSource dataSource)
		{		
			_dataSource = dataSource;
		}	

		private class AirportsDelegate : UITableViewDelegate
		{
			private readonly AirportsViewModel _viewModel;
			
			public AirportsDelegate(AirportsViewModel viewModel)
			{
				_viewModel = viewModel;
			}
			
			public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				_viewModel.SelectedAirport = _viewModel.Airports[indexPath.Row];
			}
		}		
					
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();		
				
			Title = "Airports";
			
			_dataSource.TableView = this.TableView;
			TableView.DataSource = _dataSource;
			TableView.Delegate = new AirportsDelegate(_dataSource.ViewModel);
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			_dataSource.SetSelectedRow();
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear(animated);				
			_dataSource.ViewModel.SaveCommand.Execute(null);			
		}
	}
}