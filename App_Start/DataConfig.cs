using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard_FrontEnd_Prototype
{
    public class DataConfig
    {
        public static DashboardDataStore.UserDataTable UserTable;

        public static void DataStoreInit()
        {
            UserTable = new DashboardDataStore.UserDataTable();
        }
    }
}