using System;
using System.Collections.Generic;

namespace AssetStudio
{
    public static class EnumDictionary
    {
        private static readonly Dictionary<GameType, string> _chineseNameMap = new Dictionary<GameType, string>
        {
            { GameType.Normal, "正常" },
            { GameType.UnityCN, "Unity中国版" },
            { GameType.GI, "原神" },
            { GameType.GI_Pack, "原神_Pack" },
            { GameType.GI_CB1, "原神_CB1版" },
            { GameType.GI_CB2, "原神_CB2版" },
            { GameType.GI_CB3, "原神_CB3版" },
            { GameType.GI_CB3Pre, "原神_CB3Pre版" },
            { GameType.BH3, "崩坏3" },
            { GameType.BH3Pre, "崩坏3_Pre版" },
            { GameType.BH3PrePre, "崩坏3_PrePre版" },
            { GameType.SR, "崩坏:星穹铁道" },
            { GameType.SR_CB2, "崩坏:星穹铁道-CB2版" },
            { GameType.ZZZ, "绝区零" },
            { GameType.ZZZ_CB1, "绝区零_CB1版" },
            { GameType.ZZZ_CB2, "绝区零_CB2版" },
            { GameType.TOT, "未定事件簿" },
            { GameType.GGZ, "崩坏学园2" },
            { GameType.Naraka, "永劫无间" },
            { GameType.EnsembleStar2, "偶像梦幻祭2" },
            { GameType.OPFP, "航海王热血航线" },
            { GameType.FantasyOfWind, "风之幻想" },
            { GameType.ShiningNikki, "闪耀暖暖" },
            { GameType.HelixWaltz2, "螺旋圆舞曲2蔷薇战争" },
            { GameType.NetEase, "网易游戏" },
            { GameType.AnchorPanic, "锚点降临" },
            { GameType.DreamscapeAlbireo, "梦间集天鹅座" },
            { GameType.ImaginaryFest, "魔法禁书目录幻想收束" },
            { GameType.AliceGearAegis, "机甲爱丽丝" },
            { GameType.ProjectSekai, "世界计划多彩舞台" },
            { GameType.CodenameJump, "Jump群星集结" },
            { GameType.GirlsFrontline, "少女前线2:追放" },
            { GameType.Reverse1999, "重返未来1999" },
            { GameType.ArknightsEndfield, "明日方舟:终末地" },
            { GameType.JJKPhantomParade, "咒术回战幻影夜行" },
            { GameType.MuvLuvDimensions, "MuvLuv维度" },
            { GameType.PartyAnimals, "动物派对" },
            { GameType.LoveAndDeepspace, "恋与深空" },
            { GameType.SchoolGirlStrikers, "学园少女突袭者" },
            { GameType.ExAstris, "来自星辰" },
            { GameType.CounterSide, "未来战" },
            { GameType.PerpetualNovelty, "物华弥新" },
            { GameType.PathtoNowhere, "无期迷途" },
            { GameType.WangYue, "望月" },
            { GameType.Naruto, "火影忍者" },
            { GameType.XinYueTongXing, "新月同行" },
            { GameType.SoulLand, "斗罗大陆:猎魂世界" },
            { GameType.ReturnOfTheDragonTide, "归龙潮" },
            { GameType.Arknights, "明日方舟" },
        };

        private static readonly Dictionary<LoggerEvent, string> _loggerEventChineseNameMap = new Dictionary<LoggerEvent, string>
        {
            { LoggerEvent.None, "无" },
            { LoggerEvent.Verbose, "详细" },
            { LoggerEvent.Debug, "调试" },
            { LoggerEvent.Info, "信息" },
            { LoggerEvent.Warning, "警告" },
            { LoggerEvent.Error, "错误" },
            { LoggerEvent.All, "全部" },
        };

        public static string GetChineseName(this GameType gameType)
        {
            if (_chineseNameMap.TryGetValue(gameType, out string chineseName))
            {
                return chineseName;
            }
            return gameType.ToString();
        }

        public static bool TryGetGameTypeByEnglishName(string englishName, out GameType gameType)
        {
            return Enum.TryParse(englishName, true, out gameType);
        }

        public static bool TryGetGameTypeByChineseName(string chineseName, out GameType gameType)
        {
            foreach (var pair in _chineseNameMap)
            {
                if (pair.Value == chineseName)
                {
                    gameType = pair.Key;
                    return true;
                }
            }

            gameType = GameType.Normal;
            return false;
        }

        public static List<(string EnglishName, string ChineseName)> GetAllGames()
        {
            var result = new List<(string, string)>();

            foreach (GameType gameType in Enum.GetValues(typeof(GameType)))
            {
                string englishName = gameType.ToString();
                string chineseName = gameType.GetChineseName();
                result.Add((englishName, chineseName));
            }

            return result;
        }

        public static string[] GetChineseNameArray()
        {
            var names = new List<string>();
            foreach (GameType gameType in Enum.GetValues(typeof(GameType)))
            {
                names.Add(gameType.GetChineseName());
            }
            return names.ToArray();
        }

        public static int GetIndexByChineseName(string chineseName)
        {
            var gameTypes = Enum.GetValues(typeof(GameType));
            for (int i = 0; i < gameTypes.Length; i++)
            {
                var gameType = (GameType)gameTypes.GetValue(i);
                if (gameType.GetChineseName() == chineseName)
                {
                    return i;
                }
            }
            return 0;
        }

        public static string GetChineseNameByIndex(int index)
        {
            var gameTypes = Enum.GetValues(typeof(GameType));
            if (index >= 0 && index < gameTypes.Length)
            {
                var gameType = (GameType)gameTypes.GetValue(index);
                return gameType.GetChineseName();
            }
            return GameType.Normal.GetChineseName();
        }

        public static string GetChineseName(this LoggerEvent loggerEvent)
        {
            if (_loggerEventChineseNameMap.TryGetValue(loggerEvent, out string chineseName))
            {
                return chineseName;
            }
            return loggerEvent.ToString();
        }

        public static bool TryGetLoggerEventByEnglishName(string englishName, out LoggerEvent loggerEvent)
        {
            return Enum.TryParse(englishName, true, out loggerEvent);
        }

        public static bool TryGetLoggerEventByChineseName(string chineseName, out LoggerEvent loggerEvent)
        {
            foreach (var pair in _loggerEventChineseNameMap)
            {
                if (pair.Value == chineseName)
                {
                    loggerEvent = pair.Key;
                    return true;
                }
            }

            loggerEvent = LoggerEvent.None;
            return false;
        }

        public static List<(string EnglishName, string ChineseName)> GetAllLoggerEvents()
        {
            var result = new List<(string, string)>();

            foreach (LoggerEvent loggerEvent in Enum.GetValues(typeof(LoggerEvent)))
            {
                string englishName = loggerEvent.ToString();
                string chineseName = loggerEvent.GetChineseName();
                result.Add((englishName, chineseName));
            }

            return result;
        }

        public static string[] GetLoggerEventChineseNameArray()
        {
            var names = new List<string>();
            foreach (LoggerEvent loggerEvent in Enum.GetValues(typeof(LoggerEvent)))
            {
                names.Add(loggerEvent.GetChineseName());
            }
            return names.ToArray();
        }

        public static int GetLoggerEventIndexByChineseName(string chineseName)
        {
            var loggerEvents = Enum.GetValues(typeof(LoggerEvent));
            for (int i = 0; i < loggerEvents.Length; i++)
            {
                var loggerEvent = (LoggerEvent)loggerEvents.GetValue(i);
                if (loggerEvent.GetChineseName() == chineseName)
                {
                    return i;
                }
            }
            return 0;
        }

        public static string GetLoggerEventChineseNameByIndex(int index)
        {
            var loggerEvents = Enum.GetValues(typeof(LoggerEvent));
            if (index >= 0 && index < loggerEvents.Length)
            {
                var loggerEvent = (LoggerEvent)loggerEvents.GetValue(index);
                return loggerEvent.GetChineseName();
            }
            return LoggerEvent.None.GetChineseName();
        }
    }
}