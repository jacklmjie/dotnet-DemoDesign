using System;
using System.Reflection;

namespace DemoDesign.其他
{
    public sealed class DataAccessFactory
    {
        private static readonly string assemblyPath;
        private static readonly string accessPath;

        public static IUser CreateUser()
        {
            string className = accessPath + ".User";
            return (IUser)Assembly.Load(assemblyPath).CreateInstance(className);
        }
    }

    public interface IUser
    {
        string GetUser();
        int InserUser();
    }

    public class MysqlUser : IUser
    {
        public string GetUser()
        {
            throw new NotImplementedException();
        }

        public int InserUser()
        {
            throw new NotImplementedException();
        }
    }
    public class AccessUser : IUser
    {
        public string GetUser()
        {
            throw new NotImplementedException();
        }

        public int InserUser()
        {
            throw new NotImplementedException();
        }
    }
}
