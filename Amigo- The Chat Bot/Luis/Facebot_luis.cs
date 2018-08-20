using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Amigo__The_Chat_Bot
{
    [LuisModel("d2435260-5678-4fa5-ba30-84b1545093c7", "751d307a6906483aa9fa8f8ab3924c05")]
    [Serializable]
    public class Amigo_Luis : LuisDialog<object>
    {
        [Serializable]
        public class PartialMessage
        {
            public string Text { set; get; }
        }

        [LuisIntent("hi")]
        public async Task start_conv(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("Hai   \U0001F44B");
            await Task.Delay(1000);
            await context.PostAsync("How is the day treating you?");
            context.Wait(MessageReceived);
        }
        [LuisIntent("strange")]
        public async Task strange(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("You are having mixed feelings and emotions!!! " + Environment.NewLine + Environment.NewLine+ "Wanna talk about it");
            context.Wait(MessageReceived);
        }
        [LuisIntent("")]
        public async Task none(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("I am sorry, I can't understand what you are saying");
            context.Wait(MessageReceived);
        }
        [LuisIntent("what_are_you_doing")]
        public async Task what_are_you_doing(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("I am talking to an Amazing person  \U0001F60D");
            context.Wait(MessageReceived);
        }
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("I don't know what the hell you are pointing at !!!  \U0001F620");
            context.Wait(MessageReceived);
        }
        [LuisIntent("goodmorning")]
        public async Task goodmorning(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            String message = "";
            if (result.Query.ToString().Contains("morning")) {
                message = " Good Morning !!";
            }else if (result.Query.ToString().Contains("afternoon"))
            {
                message = " Good Afternoon !!";
            }
            else if (result.Query.ToString().Contains("evening"))
            {
                message = " Good Evening !!";
            }
            else if (result.Query.ToString().Contains("night"))
            {
                message = " Good Night !!";
            }
            await context.PostAsync(message + Environment.NewLine + Environment.NewLine + "Amigo");
            context.Wait(MessageReceived);
        }
        [LuisIntent("bday")]
        public async Task birthday(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            String message = "";
            if (result.Query.ToString().Contains("birthday") || result.Query.ToString().Contains("bday"))
            {
                message = "Wow...Happy birthday to the one who is celebrating today !";
            }
            await context.PostAsync(message + Environment.NewLine + Environment.NewLine + "Amigo");
            context.Wait(MessageReceived);

        }
        [LuisIntent("bye")]
        public async Task bye(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("Bye buddy!!!"+ Environment.NewLine + Environment.NewLine + "Nice Talking to you.");
            context.Wait(MessageReceived);
        }
        [LuisIntent("disgust")]
        public async Task disgust(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("You disgust me" + Environment.NewLine + Environment.NewLine + "I dont even know why you even exist");
            context.Wait(MessageReceived);
        }
        [LuisIntent("happy")]
        public async Task happy(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync($"You look happy  \U0001F600" + Environment.NewLine + Environment.NewLine + "Can I know the reason?");
            context.Wait(MessageReceived);
        }
        [LuisIntent("congrates")]
        public async Task congrates(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("Congratulations!!... A big thumbs up for you  \U0001F44D");
            context.Wait(MessageReceived);
        }
        [LuisIntent("greatjob")]
        public async Task greatjob(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("Great job yaar!!.. Keep it up");
            context.Wait(MessageReceived);
        }

        [LuisIntent("fear")]
        public async Task fear(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            var path = Path.Combine(@"C:\Users\DELL\Documents\Amigo-master\Amigo- The Chat Bot\Data\fear.txt");
            Random r = new Random();
            Anger  fearQuotes = JsonConvert.DeserializeObject<Anger>(System.IO.File.ReadAllText(path));
            int num = r.Next(0, fearQuotes.quotes.Count);
            if (num < fearQuotes.quotes.Count && num > -1)
            {
                await context.PostAsync(fearQuotes.quotes[num].description);
                context.Wait(MessageReceived);
            }
        }
        [LuisIntent("goodtohear")]
        public async Task goodtohear(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("I'm happy for you my friend.. enjoy your day");
            context.Wait(MessageReceived);
        }
        [LuisIntent("sademotion")]
        public async Task sad(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("You sound low");
            await Task.Delay(2000);
            await context.PostAsync("This may cheer you mood");
            await Task.Delay(2000);
            Random r = new Random();
            int option = r.Next(0, 2);
            if(option == 0)
            {
                var path = Path.Combine(@"C:\Users\DELL\Documents\Amigo-master\Amigo- The Chat Bot\Data\JokesWithImages.txt");
                Jokes my_jokes = JsonConvert.DeserializeObject<Jokes>(System.IO.File.ReadAllText(path));
                int num = r.Next(0, my_jokes.jokes.Count);
                if (num < my_jokes.jokes.Count && num > -1)
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                    reply.Attachments = GetHeroCard(my_jokes.jokes[num].title,
                            my_jokes.jokes[num].subtitle, my_jokes.jokes[num].description.Replace("\n\n", " " + Environment.NewLine + Environment.NewLine + " "),
                            new CardImage(url: my_jokes.jokes[num].urlToImage),

                        new CardAction(null, "", null));
                    // new CardAction(ActionTypes.OpenUrl, "Learn more", value: jokes[num].url)); 
                    await context.PostAsync(reply);
                    context.Wait(MessageReceived);

                }
            }
            else if (option == 1)
            {
                var path = Path.Combine(@"C:\Users\DELL\Documents\Amigo-master\Amigo- The Chat Bot\Data\JokesWithoutImages.txt");
                Anger jokes = JsonConvert.DeserializeObject<Anger>(System.IO.File.ReadAllText(path));
                int n = r.Next(0, jokes.quotes.Count);
                while (n < jokes.quotes.Count && n > -1)
                {
                    await context.PostAsync(jokes.quotes[n].description);
                    context.Wait(MessageReceived);
                    break;
                }

            }
            else if(option == 2)
            {
                var path = Path.Combine(@"C:\Users\DELL\Documents\Amigo-master\Amigo- The Chat Bot\Data\ImagesJokes.txt");
                Images imageUrls = JsonConvert.DeserializeObject<Images>(System.IO.File.ReadAllText(path));
                int num = r.Next(0, imageUrls.imageQuotes.Count);
                if (num < imageUrls.imageQuotes.Count && num > -1)
                {
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = GetAnimationCard(imageUrls.imageQuotes[num].title,
                           imageUrls.imageQuotes[num].title, new CardImage(url: imageUrls.imageQuotes[num].url));
                   await context.PostAsync(reply);
                    context.Wait(MessageReceived);

                }
            }
           
           
        }

        [LuisIntent("anger")]
        public async Task anger(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            await context.PostAsync("You sound angry  \U0001F620!!!");
            await Task.Delay(1000);
            await context.PostAsync("Try this technique to cool off");
            await Task.Delay(1000);
           /*
            string[] arr = new string[20];
            arr[0] = "Count 1-20 numbers..."+Environment.NewLine +Environment.NewLine+ "it cools you down to some extent";
            arr[1] = "count 1-20 in reverse order..."+Environment.NewLine+Environment.NewLine+ "try it out without mistakes dude!!";
            arr[2] = "Try to do meditation";
            arr[3] = "Listen your favourite music" + Environment.NewLine + Environment.NewLine + "when music hits you, you feel no pain";
            arr[4] = "Inhale and exhale until you clam down"+Environment.NewLine+Environment.NewLine+ "As you exhale, repeat a phrase that helps you relax.";
            arr[5] = "Try to sleep";
            arr[6] = "Cool Off with Exercise"+Environment.NewLine+Environment.NewLine+ "Test various workouts and figure out which are most effective at calming your anger.";
            arr[7] = "Think of a pleasant memory";
            arr[8] = "Read a book";
            arr[9] = "Find your happy place"; */
            Random ra = new Random();
            var path = Path.Combine(@"C:\Users\sai vaishnavi\Documents\Visual Studio 2017\Projects\Amigo\Amigo- The Chat Bot\Amigo- The Chat Bot\Data\Anger.txt");
            Anger angerQuotes = JsonConvert.DeserializeObject<Anger>(System.IO.File.ReadAllText(path));
            int n = ra.Next(0, angerQuotes.quotes.Count);
            while (n< angerQuotes.quotes.Count && n > -1)
            {
                await context.PostAsync(angerQuotes.quotes[n].description);
                context.Wait(MessageReceived);
                break;
            }
        }
        [LuisIntent("bore")]
        public async Task bore(IDialogContext context, LuisResult result)
        {
            Amigo_Luis face = new Amigo_Luis();
            string[] arr = new string[25];
            arr[0] = "Annoy your fellow siblings with a short theme song you make up in your head";
            arr[1] = "Text your friends backwords and see how much time it take them to figure them";
            arr[2] = "Go out and follow the first person that you run into";
            arr[3] = "Switch your closet with your sibling as a prank";
            arr[4] = "Draw a horrible drawing of someone and gift it to them";
            arr[5] = "Hide somewhere and repeatedly call your housephone until a family member answers. Then hang up on them";
            arr[6] = "Make up your own language and speak in it randomly";
            arr[7] = "Create the bucket list";
            arr[8] = "Argue with someone about world ending";
            arr[9] = "Call the local shopping center and ask if they sell frogs";
            arr[10] = "try to say 'm' without closing your mouth";
            arr[12] = "Get to know the country you live in";
            arr[13] = "Play a game.." + Environment.NewLine + Environment.NewLine + "If you’re by yourself, choose an online or video game that lets you battle against the computer." + Environment.NewLine + Environment.NewLine + " If you’re with other people, consider games that let you play in teams and utilize your creativity.";
            arr[14] = "Watch a classic movie made before you were born";
            arr[15] = "Dance like there is no tomorrow ;)";
            arr[16] = "Write yourself an email to receive in the future: just do it";
            arr[17] = "Make a drink of many flavours and tell your friend to drink";
            arr[18] = "Creat a bucket list";
            arr[19] = "Do a prank call, and order a happy meal." + Environment.NewLine + Environment.NewLine + "And remember to switch off your phone after that ..   :D";
            arr[20] = "Pinterest your life away." + Environment.NewLine + Environment.NewLine + "Trust me.. It's very interesting";
            arr[21] = "Send love letters to someone you don't know";
            arr[22] = "Go to a wedding and shout 'DON'T MARRY HIM!!! I STILL LOVE YOOOOOOOOUUUUU..!!'";
            arr[23] = "Eat the whole cake! In one bite!";
            arr[24] = "Invent new names and use it to call other people";
            Random ra = new Random();
            int n = ra.Next(0, 25);
            while (n < 25)
            {
                await context.PostAsync(arr[n]);
                context.Wait(MessageReceived);
                break;
            }
        }


        public class Article
        {
            public string title { get; set; }
            public string subtitle { get; set; }
            public string description { get; set; }
            public string url { get; set; }
            public string urlToImage { get; set; }
            
        }
        public class Quotes {
            public string description { get; set; }
        }

        public class ImageQuotes
        {
            public string title { get; set; }
           // public string subtitle { get; set; }
            public string url { get; set; }
        }

        public class Images
        {
            public List<ImageQuotes> imageQuotes { get; set; }
        }

        public class Jokes
        {
            public List<Article> jokes { get; set; }
        }

        public class Anger {
            public List<Quotes> quotes { get; set; }
        }

        private static IList<Attachment> GetAnimationCard(string title, string subtitle, CardImage url)
        {
            return new List<Attachment>()
        {
             new HeroCard
            {
                Title = title,
                //Subtitle = subtitle,
                Images = new List<CardImage>() {url},
               // Buttons = new List<CardAction>() { cardAction},
             }.ToAttachment()

        };
        }


        private static IList<Attachment> GetHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            return new List<Attachment>()
        {
          new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text =  text,
                Images = new List<CardImage>() { cardImage},
               // Buttons = new List<CardAction>() { cardAction},
             }.ToAttachment()
        };
        }




    }
    
}
