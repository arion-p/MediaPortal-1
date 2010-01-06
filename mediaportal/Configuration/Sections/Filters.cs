#region Copyright (C) 2005-2009 Team MediaPortal

/* 
 *	Copyright (C) 2005-2009 Team MediaPortal
 *	http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */

#endregion

using System.Drawing;
using System.Windows.Forms;
using MediaPortal.GUI.Library;
using System;

namespace MediaPortal.Configuration.Sections
{
  public class FiltersSection : SectionSettings
  {
    private MediaPortal.UserInterface.Controls.MPTabControl mpTabControl1;
    //private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    //private MediaPortal.UserInterface.Controls.MPLabel label4;
    //private System.ComponentModel.IContainer components = null;

    public FiltersSection() : this("Codecs and Renderer") {}

    private void InitializeComponent()
    {
      this.mpTabControl1 = new MediaPortal.UserInterface.Controls.MPTabControl();
      this.SuspendLayout();
      // 
      // mpTabControl1
      // 
      this.mpTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mpTabControl1.Location = new System.Drawing.Point(0, 0);
      this.mpTabControl1.Name = "mpTabControl1";
      this.mpTabControl1.SelectedIndex = 0;
      this.mpTabControl1.Size = new System.Drawing.Size(472, 408);
      this.mpTabControl1.TabIndex = 0;
      // 
      // FiltersSection
      // 
      this.Controls.Add(this.mpTabControl1);
      this.Name = "FiltersSection";
      this.Size = new System.Drawing.Size(472, 408);
      this.ResumeLayout(false);
    }

    public override void SaveSettings()
    {
      foreach (TabPage currentTab in mpTabControl1.TabPages)
      {
        foreach (Control control in currentTab.Controls)
        {
          if (control is SectionSettings)
          {
            (control as SectionSettings).SaveSettings();
          }
        }
      }
    }

    private void OnSectionActivatedWrapper(Object sender, EventArgs e)
    {
      if (sender is TabPage)
      {
        foreach (Control control in (sender as TabPage).Controls)
        {
          if (control is SectionSettings)
          {
            (control as SectionSettings).OnSectionActivated();
            break;
          }
        }
      }
    }

    private void OnSectionDeActivatedWrapper(Object sender, EventArgs e)
    {
      if (sender is TabPage)
      {
        foreach (Control control in (sender as TabPage).Controls)
        {
          if (control is SectionSettings)
          {
            (control as SectionSettings).OnSectionDeActivated();
            break;
          }
        }
      }
    }

    public FiltersSection(string name) : base(name)
    {
      InitializeComponent();

      Log.Info("  add Video codec section");
      TabPage videoTab = new TabPage("Video Codecs");
      MovieCodec mc = new MovieCodec();
      mc.Dock = DockStyle.Fill;
      mc.OnSectionActivated();
      videoTab.Enter += new System.EventHandler(OnSectionActivatedWrapper);
      videoTab.Leave += new System.EventHandler(OnSectionDeActivatedWrapper);
      videoTab.Controls.Add(mc);
      mpTabControl1.TabPages.Add(videoTab);

      Log.Info("  add TV codec section");
      TabPage tvTab = new TabPage("TV Codecs");
      TVCodec tc = new TVCodec();
      tc.Dock = DockStyle.Fill;
      tvTab.Enter += new System.EventHandler(OnSectionActivatedWrapper);
      tvTab.Leave += new System.EventHandler(OnSectionDeActivatedWrapper);
      tvTab.Controls.Add(tc);
      mpTabControl1.TabPages.Add(tvTab);

      Log.Info("  add DVD codec section");
      TabPage dvdTab = new TabPage("DVD Codecs");
      DVDCodec dc = new DVDCodec();
      dc.Dock = DockStyle.Fill;
      dvdTab.Enter += new System.EventHandler(OnSectionActivatedWrapper);
      dvdTab.Leave += new System.EventHandler(OnSectionDeActivatedWrapper);
      dvdTab.Controls.Add(dc);
      mpTabControl1.TabPages.Add(dvdTab);

      Log.Info("  add Renderer section");
      TabPage rendererTab = new TabPage("Video Renderer");
      FiltersVideoRenderer renderConfig = new FiltersVideoRenderer();
      renderConfig.Dock = DockStyle.Fill;
      rendererTab.Enter += new System.EventHandler(OnSectionActivatedWrapper);
      rendererTab.Leave += new System.EventHandler(OnSectionDeActivatedWrapper);
      rendererTab.Controls.Add(renderConfig);
      mpTabControl1.TabPages.Add(rendererTab);
    }
  }
}