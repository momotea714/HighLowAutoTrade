using HighLowAutoTradeCore.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HighLowAutoTradeCore.Biz.Extensions;

namespace HighLowAutoTradeCore
{
    public class HighLowAutoTradeEngine
    {
        #region Field

        private TradeType _tradeType;
        private int _tradeAmount;
        private TradeDirection _tradeDirection;

        #endregion

        #region Property

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

        #region Constractor

        public HighLowAutoTradeEngine(int tradeType, int tradeAmount, int tradeDirection)
        {
            _tradeType = tradeType.ToEnum<TradeType>();
            _tradeAmount = tradeAmount;
            _tradeDirection = tradeDirection.ToEnum<TradeDirection>();
        }

        #endregion

        #region Public-Method

        public void Execute()
        {
            // AppSettings.BrowserName.Firefoxを変更することによって対象のブラウザを変更できます
            using (IWebDriver webDriver = WebDriverFactory.CreateInstance(BrowserName.Chrome))
            {
                webDriver.Url = @"https://jp.trade.highlow.net/";

                webDriver.FindElement(By.XPath(@"//*[@id=""header""]/div/div/div/div/div/span/span/a[2]")).Click();
                webDriver.FindElement(By.Id("username-email")).SendKeys("HL238880");
                webDriver.FindElement(By.Id("password")).SendKeys("Hermione71");
                webDriver.FindElement(By.Id("login-trigger-button")).Click();
                webDriver.FindElement(By.XPath(@"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[1]")).Click();
                // 一瞬で完了するため3秒スリープ
                //Thread.Sleep(TimeSpan.FromSeconds(3));

                // ブラウザを閉じる
                //webDriver.Quit();
            }
        }

        #endregion

        #region Private-Method

        private string GetGameTypeXPath()
        {
            switch (_tradeType)
            {
                case TradeType.HighLow_15min:
                case TradeType.HighLow_1hour:
                case TradeType.HighLow_1day:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[1]";
                case TradeType.HighLowSpread_15min:
                case TradeType.HighLowSpread_1hour:
                case TradeType.HighLowSpread_1day:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[2]";
                case TradeType.HighLowTurbo_30sec:
                case TradeType.HighLowTurbo_1min:
                case TradeType.HighLowTurbo_3min:
                case TradeType.HighLowTurbo_5min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[3]";
                case TradeType.HighLowTurboSpread_30sec:
                case TradeType.HighLowTurboSpread_1min:
                case TradeType.HighLowTurboSpread_3min:
                case TradeType.HighLowTurboSpread_5min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[4]";
                default:
                    return string.Empty;
            }
        }

        private string GetCategoryFilterXPath()
        {
            switch (_tradeType)
            {

                case TradeType.HighLowTurbo_30sec:
                case TradeType.HighLowTurboSpread_30sec:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[2]";
                case TradeType.HighLowTurboSpread_1min:
                case TradeType.HighLowTurbo_1min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[3]";
                case TradeType.HighLowTurbo_3min:
                case TradeType.HighLowTurboSpread_3min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[4]";
                case TradeType.HighLowTurboSpread_5min:
                case TradeType.HighLowTurbo_5min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[5]";
                case TradeType.HighLow_15min:
                case TradeType.HighLowSpread_15min:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[1]";
                case TradeType.HighLow_1hour:
                case TradeType.HighLowSpread_1hour:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[2]";
                case TradeType.HighLowSpread_1day:
                case TradeType.HighLow_1day:
                    return @"//*[@id=""assetsGameTypeZoneRegion""]/ul/li[3]";
                default:
                    return string.Empty;
            }
        }

        #endregion


    }
}