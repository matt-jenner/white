using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteComboBoxPeer : ComboBoxAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;

        public WhiteComboBoxPeer(ComboBox owner) : base(owner)
        {
            whitePeer = WhitePeer.CreateForValueProvider(this, owner, () => owner.SelectedItem == null ? string.Empty : owner.SelectedItem.ToString(),
                                                         delegate(string value)
                                                             {
                                                                 foreach (ComboBoxItem item in owner.Items)
                                                                 {
                                                                     if (Equals(item.Name, value))
                                                                         item.IsSelected = true;
                                                                 }
                                                             });
        }

        public void SetValue(string commandString)
        {
            whitePeer.SetValue(commandString);
        }

        public string Value
        {
            get { return whitePeer.Value; }
        }

        public bool IsReadOnly
        {
            get { return whitePeer.IsReadOnly; }
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }
    }
}