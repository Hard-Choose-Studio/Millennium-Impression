using System.Collections.Generic;

namespace MillenniumImpression
{
    public static class StoryData
    {
        public static readonly Dictionary<Scenes, string[]> stories = new()
        {
            {
                Scenes.AquaOilScene,
                new string[]
                {
                    "下午要開始唸書了，",
                    "一想到要面對那些教科書，",
                    "就令我提不起勁，",
                    "只好拿出我的提神好夥伴——",
                    "綠油精。",
                    "一打開綠油精，",
                    "那一股涼爽的薄荷香氣瞬間充滿了整個房間，",
                    "猶如一股清新的力量，",
                    "讓我打起精神，",
                    "去戰勝那些艱澀的知識。"
                }
            },
            {
                Scenes.TapeScene,
                new string[]
                {
                    "為了讓接下來的學習時光更加愉快，",
                    "我決定放一些音樂來聽。",
                    "受到媽媽的影響，",
                    "除了最近流行的那些歌曲以外，",
                    "我也很喜歡比較早期的卡帶，",
                    "覺得它比起便捷的CD，",
                    "倒帶、翻面等專屬於卡帶的操作，",
                    "使它有著與眾不同的風味。",
                    "儘管已不再流行，",
                    "卡帶上的音樂仍使我沈浸其中，",
                    "找到了一絲心靈的寧靜和安慰。"
                }
            }
        };

        public static Scenes nextScene;
    }
}