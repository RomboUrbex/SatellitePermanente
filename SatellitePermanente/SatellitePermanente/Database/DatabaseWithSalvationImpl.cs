﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SatellitePermanente.LogicAndMath
{
    class DatabaseWithSalvationImpl: DatabaseImpl,DatabaseWithSalvatation
    {
        private OriginDatabase database { get; set; }
        private Boolean saved, loaded;

        /*Builder*/
        public DatabaseWithSalvationImpl()
        {
            this.database = new OriginDatabaseImpl();
            this.saved = false;
            this.loaded = false;
           
        }

        public Boolean SalveDatabase()
        {
            this.database.pointList = base.pointList;
            this.database.nodeList = base.nodeList;

            String json = JsonConvert.SerializeObject(this.database);
            System.IO.File.WriteAllText("Database.txt", json);

            this.saved = true;
            return File.Exists("Database.txt");
        }

        public Boolean LoadDatabase()
        {
            if (File.Exists("Database.txt"))
            {
                this.database = JsonConvert.DeserializeObject<OriginDatabase>("Database.txt");

                if (this.database.pointList.Count >0)
                {
                    this.loaded = true;

                    base.pointList = this.database.pointList;
                    base.nodeList = this.database.nodeList;
                    return true;
                }
            }

            return false;
        }

    }
}