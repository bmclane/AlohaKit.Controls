﻿namespace AlohaKit.Controls
{
    public class VerticalProgressBarDrawable : IDrawable
    {
        public Paint BackgroundPaint { get; set; }
        public Paint ProgressPaint { get; set; }
        public double Progress { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Antialias = true;

            DrawTrack(canvas, dirtyRect);

            DrawProgress(canvas, dirtyRect);
        }

        public virtual void DrawTrack(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            canvas.SetFillPaint(BackgroundPaint, dirtyRect);

            var x = (float)(dirtyRect.Width / 2);
            var y = dirtyRect.Y;

            var width = dirtyRect.Width;
            var height = dirtyRect.Height;

            canvas.FillRectangle(x, y, width, height);

            canvas.RestoreState();
        }

        public virtual void DrawProgress(ICanvas canvas, RectF dirtyRect)
        {
            canvas.SaveState();

            canvas.SetFillPaint(ProgressPaint, dirtyRect);

            var x = (float)(dirtyRect.Width / 2);
            var y = dirtyRect.Y + dirtyRect.Height;

            var width = dirtyRect.Width;
            var height = dirtyRect.Height;

            canvas.FillRectangle(x, y, width, -(float)(height * Progress));

            canvas.RestoreState();
        }
    }
}