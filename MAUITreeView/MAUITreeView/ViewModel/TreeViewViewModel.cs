﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUITreeView
{
    public class TreeViewViewModel
    {
        #region Fields

        private ObservableCollection<Countries> imageNodeInfo;

        #endregion

        #region Constructor

        public TreeViewViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<Countries> ImageNodeInfo
        {
            get { return imageNodeInfo; }
            set { this.imageNodeInfo = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("MAUITreeView.Data.navigation.json");
            using (StreamReader sr = new StreamReader(stream))
            {
                var jsonText = sr.ReadToEnd();
                ImageNodeInfo = new ObservableCollection<Countries>();
                var MyArrayData = JsonConvert.DeserializeObject<List<Countries>>(jsonText);
                foreach (var data in MyArrayData)
                {
                    ImageNodeInfo.Add(data);
                }
            }
        }

        #endregion
    }
}
