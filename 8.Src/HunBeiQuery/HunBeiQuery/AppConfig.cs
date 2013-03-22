using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunBeiQuery
{
    public class AppConfig
    {

#region Default
/// <summary>
/// 
/// </summary>
static public AppConfig Default
{
	get
	{
        if (_default == null)
        {
            _default = new AppConfig();
            _default.Title = System.Configuration.ConfigurationSettings.AppSettings["Title"];
        }
		return _default;
	}
} static private AppConfig _default;
#endregion //Default

#region Title
/// <summary>
/// 
/// </summary>
public string Title
{
	get
	{
		if (_title == null)
		{
			_title = string.Empty;
		}
		return _title;
	}
	set
	{
		_title = value;
	}
} private string _title;
#endregion //Title

    }

}