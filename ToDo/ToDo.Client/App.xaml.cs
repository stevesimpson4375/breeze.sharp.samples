﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Breeze.Sharp.Core;
using Breeze.Sharp;

using Todo.Models;

namespace Todo_Net
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TodoViewModel _mainViewModel;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the Breeze entity manager
            var serviceAddress = "http://localhost:63030/breeze/Todos/";
            //var serviceAddress = "http://sampleservice.breezejs.com/api/todos/";
            var assembly = typeof(TodoItem).Assembly;
            var rslt = Configuration.Instance.ProbeAssemblies(assembly);
            var entityManager = new EntityManager(serviceAddress);

            // Create the main viewModel and view
            _mainViewModel = new TodoViewModel(entityManager);
        }

        /// <summary>
        /// Supplies the main view when requested by the main window
        /// </summary>
        public UserControl MainView 
        {
            get { return _mainViewModel.View; }
        }
    }
}
