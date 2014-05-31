using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LiveSplit.TimesaveRemaining
{
    public class TimesaveRemainingComponent : IComponent
    {
        private InfoTimeComponent component;
        private LiveSplitState state;
        private GraphicsCache cache;

        public string ComponentName { get { return "Time Save Remaining"; } }
        public IDictionary<string, Action> ContextMenuControls { get; protected set; }

        public float HorizontalWidth { get { return component.HorizontalWidth; } }
        public float MinimumHeight { get { return component.MinimumHeight; } }
        public float MinimumWidth { get { return component.MinimumWidth; } }
        public float PaddingBottom { get { return component.PaddingBottom; } }
        public float PaddingLeft { get { return component.PaddingLeft; } }
        public float PaddingRight { get { return component.PaddingRight; } }
        public float PaddingTop { get { return component.PaddingTop; } }
        public float VerticalHeight { get { return component.VerticalHeight; } }

        public TimesaveRemainingComponent(LiveSplitState state)
        {
            component = new InfoTimeComponent(null, null, new RegularTimeFormatter(TimeAccuracy.Hundredths));
            component.NameLabel.Text = "Time Save Remaining";
            this.state = state;
            cache = new GraphicsCache();

            ContextMenuControls = new Dictionary<string, Action>();

            //Recalculate conditions:
            state.OnStart += Recalculate;
            state.OnSplit += Recalculate;
            state.OnSkipSplit += Recalculate;
            state.OnSplit += Recalculate;
        }

        void Recalculate(object sender, EventArgs e)
        {
            component.TimeValue = new TimeSpan(); //Reset value
            for (int i = state.CurrentSplitIndex; i < state.Run.Count; i++)
            {
                //Much Math, Such complicated
                ISegment segment = state.Run[i];
                TimeSpan? segmentTime;
                if (i == 0)
                {
                    segmentTime = segment.PersonalBestSplitTime;
                }
                else
                {
                    ISegment prevSegment = state.Run[i - 1];
                    segmentTime = segment.PersonalBestSplitTime - prevSegment.PersonalBestSplitTime;
                }
                component.TimeValue += (segmentTime - segment.BestSegmentTime);
            }
        }

        public void DrawHorizontal(System.Drawing.Graphics g, LiveSplitState state, float height, System.Drawing.Region clipRegion)
        {
            component.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            component.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
            component.DrawHorizontal(g, state, height, clipRegion);
        }

        public void DrawVertical(System.Drawing.Graphics g, LiveSplitState state, float width, System.Drawing.Region clipRegion)
        {
            component.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            component.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
            component.DrawVertical(g, state, width, clipRegion);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return document.CreateElement("Settings");
        }

        public System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            return null;
        }

        public void RenameComparison(string oldName, string newName){}
        public void SetSettings(XmlNode settings){}

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            //Needed so the component gets updated properly? (Otherwise it would just update the first few seconds and not react afterwards)
            cache.Restart();
            cache["TimeValue"] = component.ValueLabel.Text;
            if (invalidator != null && cache.HasChanged)
                invalidator.Invalidate(0f, 0f, width, height);
        }
    }
}
