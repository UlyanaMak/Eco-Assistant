using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Recycler
{
    public class Article
    {
        public string Header { get; }
        public string[] Elements { get; }
        public enum HorizontalOptions { Left, Right }
        public HorizontalOptions Options { get; }
        public Button Button { get; set; }

        public Article(string header, string[] elements, HorizontalOptions options)
        {
            Header = header; 
            Elements = elements; 
            Options = options;
        }
		public Article(string header, string[] elements, HorizontalOptions options, Button button)
		{
			Header = header; 
            Elements = elements;
            Options = options;
            Button = button;
            if (options == HorizontalOptions.Left) button.HorizontalOptions = LayoutOptions.Start;
            else if (options == HorizontalOptions.Right) button.HorizontalOptions = LayoutOptions.End;
		}
	}
}
