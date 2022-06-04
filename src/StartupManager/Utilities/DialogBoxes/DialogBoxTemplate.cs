using System.Windows.Forms;

namespace Dawn.Apps.StartupManager.DialogBoxes;

public abstract class DialogBoxTemplate<T> : Form
{
    public T Result { get; protected set; }
}