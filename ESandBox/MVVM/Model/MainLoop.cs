using System;
using System.Threading.Tasks;

namespace ESandBox.MVVM.Model
{
    static class MainLoop
    {
        private static bool isRunning;

        internal static void Start()
        {
            isRunning = true;
            Task.Run(Loop);
        }

        internal static void Stop() { isRunning = false; }

        private static void Loop()
        {
            var tps = 20;
            var interval = TimeSpan.FromMilliseconds(1000 / tps);
            var maxFrameSkip = 5;

            var currentTime = DateTime.Now;
            int loops = 0;
            double interpolation;
            while (isRunning)
            {
                loops = 0;
                while ( DateTime.Now > currentTime && loops < maxFrameSkip)
                {
                    // update
                    currentTime += interval;
                    loops++;
                }
                interpolation = (DateTime.Now + interval - currentTime).TotalMilliseconds / interval.TotalMilliseconds;
                // render(interpolation)
                Rendering.Render();
            }
        }
    }
}
