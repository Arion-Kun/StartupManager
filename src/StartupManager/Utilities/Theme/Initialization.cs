namespace Dawn.Apps.StartupManager;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Extensions;

internal static class Theme
{
    internal static void Initialize(Start start)
    {
        var strip = start.TrayIcon.ContextMenuStrip;
        strip.RenderMode = ToolStripRenderMode.Professional;
        RecolorTrayMenus(strip);
        DarkMode(start);
    }

    private static void RecolorTrayMenus(ToolStrip strip)
    {
        var midnightBlue = Color.FromArgb(27, 34, 46);
        var slateGray = Color.FromArgb(95, 126, 151);
        var border = Color.FromArgb(26, 37, 53);
        // var slateGray = Color.FromArgb(border.R+5, border.G+5, border.B+5);

        
        strip.RenderMode = ToolStripRenderMode.Professional;
        strip.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable(slateGray, midnightBlue, border));
        IterateItems(strip.Items, midnightBlue, slateGray);
    }

    internal static void DarkMode(Control control)
    {
        if (control == null) return;
        if (control.Name.StartsWith("__")) return;
        var midnightBlue = Color.FromArgb(27, 34, 46);
        var slateGray = Color.FromArgb(95, 126, 151);
        control.ForeColor = slateGray;
        control.BackColor = midnightBlue;
        foreach (Control component in control?.Controls)
        {
            DarkMode(component);
            if (component.Name.StartsWith("__")) continue; // Prefix Marker for non-themeable controls
            switch (component)
            {
                case Panel p:
                    if (p.ForeColor == Color.White)
                        p.ForeColor = slateGray;
                    p.BackColor = midnightBlue;
                    break;
                case TextBox:
                    if (component.ForeColor == Color.White)
                        component.ForeColor = slateGray;
                    component.BackColor = midnightBlue;
                    break;
                case Button b:
                    b.FlatStyle = FlatStyle.Flat;
                    b.ForeColor = slateGray;
                    b.BackColor = Color.FromArgb(midnightBlue.R-10, midnightBlue.G-10, midnightBlue.B-10);
                    break;
                case ToolStrip strip:
                    RecolorTrayMenus(strip);
                    break;
                case DataGridView grid:
                    grid.ForeColor = slateGray;
                    grid.BackColor = midnightBlue;
                    grid.BackgroundColor = midnightBlue;
                    grid.GridColor = slateGray;
                    
                    grid.EnableHeadersVisualStyles = false;

                    grid.DefaultCellStyle.BackColor = midnightBlue;
                    if (grid.DefaultCellStyle.ForeColor == Color.White)
                        grid.DefaultCellStyle.ForeColor = slateGray;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = slateGray;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = midnightBlue;
                    
                    // grid.ColumnHeadersBorderStyle = 
                    foreach (DataGridViewColumn gridColumn in grid.Columns)
                    {
                        if (gridColumn.InheritedStyle != null)
                        {
                            gridColumn.InheritedStyle.ForeColor = slateGray;
                            gridColumn.InheritedStyle.BackColor = midnightBlue;
                        }

                        if (gridColumn.DefaultCellStyle.ForeColor == Color.White)
                            gridColumn.DefaultCellStyle.ForeColor = slateGray;
                        gridColumn.DefaultCellStyle.BackColor = midnightBlue;
                        gridColumn.DefaultCellStyle.SelectionBackColor = midnightBlue;
                        gridColumn.DefaultCellStyle.SelectionForeColor = slateGray;

                        switch (gridColumn)
                        {
                            case DataGridViewButtonColumn buttonColumn:
                                // buttonColumn.CellTemplate.
                                buttonColumn.CellTemplate.Style.ForeColor = slateGray;
                                buttonColumn.DefaultCellStyle.ForeColor = slateGray;
                                // buttonColumn.CellTemplate.Style.SelectionBackColor = Color.Black;
                                // buttonColumn.CellTemplate.Style.SelectionForeColor = Color.Black;
                                // buttonColumn.DefaultCellStyle.SelectionBackColor = Color.Black;
                                // buttonColumn.DefaultCellStyle.SelectionForeColor = Color.Black;
                                break;
                        }

                        // if (gridColumn.CellType != typeof(DataGridViewLinkCell)) continue;
                        // if (gridColumn is not DataGridViewLinkColumn link) continue;
                        // link.LinkBehavior = LinkBehavior.NeverUnderline;
                        // link!.LinkColor = slateGray;
                        // link.VisitedLinkColor = Color.SkyBlue;
                        // var linkcell = (DataGridViewLinkCell)link.CellTemplate;
                        // linkcell.LinkColor = slateGray;
                        // linkcell.VisitedLinkColor = Color.SkyBlue;
                        // linkcell.ActiveLinkColor = Color.SkyBlue;
                        // linkcell.VisitedLinkColor = Color.SkyBlue;
                    }
                    foreach (DataGridViewRow gridRow in grid.Rows)
                    {
                        foreach (DataGridViewCell gridRowCell in gridRow.Cells)
                        {
                            switch (gridRowCell)
                            {
                                case DataGridViewLinkCell linkCell:
                                    // linkCell.LinkColor = Color.FromArgb(100, 216, 170);
                                    linkCell.LinkColor = Color.FromArgb(55, 139, 184);
                                    linkCell.VisitedLinkColor = slateGray;
                                    linkCell.ActiveLinkColor = Color.SkyBlue;
                                    break;
                                case DataGridViewTextBoxCell textCell:
                                    if (textCell.Style.ForeColor == Color.White)
                                        textCell.Style.ForeColor = slateGray;
                                    break;
                                // case DataGridViewButtonCell button:
                                //     button.Style.ForeColor = Color.FromArgb(255, 100, 216, 170);
                                //     button.Style.BackColor = midnightBlue;
                                //     break;
                            }
                        }
                    }
                    break;

            }
        }
    }
    private static void IterateItems(ToolStripItemCollection strips, Color backColor, Color foreColor)
    {
        foreach (ToolStripItem stripItem in strips)
        {
            switch (stripItem)
            {
                case ToolStripMenuItem item:
                    item.BackColor = backColor;
                    item.ForeColor = foreColor;
                    IterateItems(item.DropDownItems, backColor, foreColor);
                    item.ImageTransparentColor = Color.White;
                    break;
                case ToolStripSeparator separator:
                    separator.BackColor = backColor;
                    separator.ForeColor = foreColor;
                    break;
                case ToolStripDropDownItem dropDownItem:
                    dropDownItem.BackColor = backColor;
                    dropDownItem.ForeColor = foreColor;
                    break;
                case ToolStripComboBox stripComboBox:
                    stripComboBox.BackColor = backColor;
                    stripComboBox.ForeColor = foreColor;
                    if (stripComboBox.ComboBox != null)
                    {
                        stripComboBox.ComboBox.BackColor = backColor;
                        stripComboBox.ComboBox.ForeColor = foreColor;
                    }
                    break;
            }
        }
    }

    private class CustomColorTable : ProfessionalColorTable
    {
        internal CustomColorTable(Color front, Color back, Color border)
        {
            UseSystemColors = false;
            Front = front;
            Back = back;
            Border = border;
            Select2 = Color.FromArgb(border.R+5, border.G+5, border.B+5);
        }
        private Color Front { get; }
        private Color Back { get; }
        private Color Border { get; }
        private Color Select2 { get; }
        
        public override Color MenuItemSelected => Select2;
        // public override Color MenuItemSelectedGradientBegin => Front;
        // public override Color MenuItemSelectedGradientEnd => Back;
        public override Color MenuItemBorder => Select2;
        public override Color ToolStripBorder => Back;
        public override Color ButtonSelectedBorder => Back;
        public override Color MenuBorder => Back;
        
        public override Color ImageMarginGradientBegin => Back;

        public override Color ImageMarginGradientMiddle => Back;

        public override Color ImageMarginGradientEnd => Back;

        public override Color ToolStripDropDownBackground => Back;
        public override Color SeparatorLight => Front;
        public override Color ButtonSelectedHighlight => Select2;
        public override Color ButtonPressedHighlight => Select2;
        public override Color MenuStripGradientBegin => Select2;
        public override Color MenuStripGradientEnd => Select2;
        public override Color MenuItemSelectedGradientBegin => Select2;
        public override Color MenuItemSelectedGradientEnd => Select2;
    }
}