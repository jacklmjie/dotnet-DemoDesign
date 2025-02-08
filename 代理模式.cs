using DemoDesign.其他;
using System;
using Xunit;

namespace DesignMode
{
    /// <summary>
    /// 为其他对象提供一种代理以控制对这个对象的访问
    /// </summary>
    public class 代理模式
    {
        public interface IDBAction
        {
            void Add();
            int Delete();
            string GetPermission();
        }

        public class DBManager : IDBAction
        {
            private readonly string _permisssion;

            public DBManager(string permisssion)
            {
                this._permisssion = permisssion;
            }

            public void Add()
            {
                throw new NotImplementedException();
            }

            public int Delete()
            {
                throw new NotImplementedException();
            }

            public string GetPermission()
            {
                return _permisssion;
            }
        }

        public class DBManagerProxy : IDBAction
        {
            private IDBAction _dBAction;
            public DBManagerProxy(IDBAction dBAction)
            {
                _dBAction = dBAction;
            }

            public string GetPermission()
            {
                return _dBAction.GetPermission();
            }

            public void Add()
            {
                if (GetPermission() == "CanAdd")
                {
                    _dBAction.Add();
                }
            }

            public int Delete()
            {
                throw new NotImplementedException();
            }
        }

        public class DBClient
        {
            [Fact]
            public void Test()
            {
                IDBAction db = new DBManagerProxy(new DBManager("CanAdd"));
                db.Add();
            }
        }
    }
}
