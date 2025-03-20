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

            string[] filmList = {
            "Review Film The Lion King oleh Edgar",
            "Review Film Aladdin oleh Edgar",
            "Review Film Beauty and the Beast oleh Edgar",
            "Review Film Frozen oleh Edgar",
            "Review Film Moana oleh Edgar",
            "Review Film Tangled oleh Edgar",
            "Review Film The Little Mermaid oleh Edgar",
            "Review Film Mulan oleh Edgar",
            "Review Film Zootopia oleh Edgar",
            "Review Film Encanto oleh Edgar"
        };

            foreach (var title in filmList)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
                video.IncreasePlayCount(new Random().Next(1, 10000));
                video.PrintVideoDetails();
            }

            Console.WriteLine();
            user.PrintAllVideoPlayCount();
            Console.WriteLine($"Total Play Count: {user.GetTotalVideoPlayCount()}");
        }
    }
}
