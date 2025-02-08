using System;
using Xunit;

namespace DesignMode
{
    /// <summary>
    /// 将一个类的接口转换成客户希望的另外一个接口
    /// Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
    /// </summary>
    public class 适配器模式
    {
        [Fact]
        public void Test()
        {
            var ba = new BirdAdapter(new Brid1());
            ba.ShowType();
            ba.ToTweet();
        }

        interface ITweetable
        {
            void ToTweet();
        }

        public class BirdAdapter : ITweetable
        {
            private readonly Brid _brid;

            public BirdAdapter(Brid brid)
            {
                _brid = brid;
            }

            public void ShowType()
            {
                _brid.ShowType();
            }

            public void ToTweet()
            {
                //为不同的子类实现不同的ToTweet
            }
        }

        public abstract class Brid
        {
            public abstract void ShowType();

            //public virtual void ShowType()
            //{
            //    //virtual必须得有具体的实现，不然得用虚方法abstract
            //}
        }

        public class Brid1 : Brid
        {
            public override void ShowType()
            {
                throw new NotImplementedException();
            }
        }

        public class Brid2 : Brid
        {
            public override void ShowType()
            {
                throw new NotImplementedException();
            }
        }
    }
}
