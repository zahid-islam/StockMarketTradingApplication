using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTradex.UI.App_Code
{
    public static class Global
    {
            /// <summary>
            /// Global variable that is constant.
            /// </summary>
            //public const string GlobalString = "Important Text";

            /// <summary>
            /// Static value protected by access routine.
            /// </summary>
            static string _globalValue;

            /// <summary>
            /// Access routine for global variable.
            /// </summary>
            public static string GlobalValueRandom
            {
                get
                {
                    return _globalValue;
                }
                set
                {
                    _globalValue = value;
                }
            }

            /// <summary>
            /// Global static field.
            /// </summary>
            //public static bool GlobalBoolean;
        }
}