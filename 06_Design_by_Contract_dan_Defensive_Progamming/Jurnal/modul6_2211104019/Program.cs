using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul6_2211104019
{
    class Program
    {
        static void Main()
        {
            SayaTubeUser user = new SayaTubeUser("Edgar");
            List<string> filmList = new List<string>
        {
            "Review Film Lion King oleh Edgar",
            "Review Film Toy Story oleh Edgar",
            "Review Film Aladdin oleh Edgar",
            "Review Film Mulan oleh Edgar",
            "Review Film Frozen oleh Edgar",
            "Review Film Moana oleh Edgar",
            "Review Film Cars oleh Edgar",
            "Review Film Finding Nemo oleh Edgar",
            "Review Film Ratatouille oleh Edgar",
            "Review Film Coco oleh Edgar"
        };

            foreach (var title in filmList)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
                video.IncreasePlayCount(new Random().Next(1, 10000));
                video.PrintVideoDetails();
            }

            Console.WriteLine();
            user.PrintAllVideoPlaycount();
            Console.WriteLine($"Total Play Count: {user.GetTotalVideoPlayCount()}");
        }
    }
}
