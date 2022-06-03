using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace YoutubeAudioDownloader2.Controls
{
    public sealed class ColoredProgressBar : ProgressBar
    {
        #region GLOBAL_VARIABLES
        private const string DefultBackgroundColor = "#FBFBFB";
        private const string DefaultProgressColor = "#06b025";

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(typeof(Color), "Control")]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25")]
        public override Font Font { get => base.Font; set => base.Font = value; }

        [DefaultValue(typeof(Color), DefultBackgroundColor)]
        public Color BackgroundColor { get; set; }

        [DefaultValue(typeof(Color), DefaultProgressColor)]
        public Color ProgressColor { get; set; }

        [DefaultValue(false)]
        public bool ShowPercentageText { get; set; }
        #endregion

        #region CONSTRUCTOR
        public ColoredProgressBar()
        {
            DoubleBuffered = true;

            if (ProgressBarRenderer.IsSupported)
            {
                SetStyle(ControlStyles.UserPaint, true);
            }

            BackgroundColor = ColorTranslator.FromHtml(DefultBackgroundColor);
            ProgressColor = ColorTranslator.FromHtml(DefaultProgressColor);
            ShowPercentageText = false;
        }
        #endregion

        #region COMPONENT_EVENTS
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!ProgressBarRenderer.IsSupported)
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image offscreenImage = new Bitmap(Width, Height))
            {
                using Graphics mainGraphics = Graphics.FromImage(offscreenImage);

                Color progressColor = ProgressColor;

                Rectangle baseRectangle = new(Point.Empty, Size);
                ProgressBarRenderer.DrawHorizontalBar(mainGraphics, baseRectangle);
                baseRectangle.Inflate(new Size(-2, -2));

                mainGraphics.FillRectangle(new SolidBrush(BackgroundColor), baseRectangle);

                Rectangle mainRectangle = new(Point.Empty, Size);
                mainRectangle.Inflate(new Size(-1, -1));
                mainRectangle.Width = (int)Math.Truncate((double)mainRectangle.Width * Value / Maximum);

                if (mainRectangle.Width == 0)
                {
                    mainRectangle.Width = 1;

                    progressColor = SystemColors.Control;
                }

                var verticalBrush = new LinearGradientBrush(mainRectangle, BackColor, progressColor, LinearGradientMode.Vertical)
                {
                    InterpolationColors = new ColorBlend
                    {
                        Positions = new float[]
                        {
                                0.0f,
                                0.55f,
                                1.0f
                        },
                        Colors = new Color[]
                        {
                                BackColor,
                                progressColor,
                                BackColor
                        }
                    }
                };

                mainGraphics.FillRectangle(verticalBrush, mainRectangle);

                LinearGradientBrush horizontalBrush = new(mainRectangle, progressColor, BackColor, LinearGradientMode.Horizontal)
                {
                    GammaCorrection = true,
                    InterpolationColors = new ColorBlend
                    {
                        Positions = new float[]
                        {
                            0.0f,
                            0.35f,
                            0.65f,
                            1.0f
                        },
                        Colors = new Color[]
                        {
                            Color.FromArgb(200, progressColor),
                            Color.FromArgb(100, progressColor),
                            Color.FromArgb(100, progressColor),
                            Color.FromArgb(200, progressColor)
                        }
                    }
                };

                mainGraphics.FillRectangle(horizontalBrush, mainRectangle);

                Pen mainPen = new(Color.FromArgb(80, Color.White));
                mainGraphics.DrawLine(mainPen, 1, 1, 1, mainRectangle.Height);
                mainGraphics.DrawLine(mainPen, mainRectangle.Width, 1, mainRectangle.Width, mainRectangle.Height);

                Rectangle highBarRectangle = new(1, 1, mainRectangle.Width, (int)Math.Truncate(mainRectangle.Height * 0.45));

                LinearGradientBrush highBarBrush = new(highBarRectangle, Color.White, Color.White, LinearGradientMode.Vertical)
                {
                    GammaCorrection = true,
                    InterpolationColors = new ColorBlend
                    {
                        Positions = new float[]
                        {
                            0.0f,
                            0.3f,
                            1.0f
                        },
                        Colors = new Color[]
                        {
                            Color.FromArgb(120, Color.White),
                            Color.FromArgb(110, Color.White),
                            Color.FromArgb(80, Color.White)
                        }
                    }
                };

                mainGraphics.FillRectangle(highBarBrush, highBarRectangle);
                e.Graphics.DrawImage(offscreenImage, Point.Empty);

                if (ShowPercentageText)
                {
                    using StringFormat stringFormat = new();

                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    e.Graphics.DrawString(Value + "%", Font, new SolidBrush(ForeColor), new Rectangle(0, 0, Width, Height), stringFormat);
                }
            }

            base.OnPaint(e);
        }
        #endregion
    }
}