using System;

namespace DemoDesign.其他
{
    /// <summary>
    /// 封装
    /// </summary>
    public class ATM
    {
        #region 定义私有方法，隐藏具体实现
        private ClientUser GetUser(string userID) { return new ClientUser(); }
        private bool IsValidUser(ClientUser user) { return true; }
        private int GetCash(int money) { return 0; }
        #endregion

        #region 定义公有方法，提供对外接口
        public void CashProcess(string userID, int money)
        {
            ClientUser tempUser = GetUser(userID);
            if (IsValidUser(tempUser))
            {
                GetCash(money);
            }
            else
            {
                Console.WriteLine("不是合法用户");
            }
        }
        #endregion
    }

    /// <summary>
    /// 用户类
    /// </summary>
    public class ClientUser
    {

    }
}
