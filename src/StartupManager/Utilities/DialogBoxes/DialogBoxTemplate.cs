using System.Windows.Forms;

namespace StartupManager.DialogBoxes;

public abstract class DialogBoxTemplate<T> : Form
{
    public T Result { get; protected set; }
}