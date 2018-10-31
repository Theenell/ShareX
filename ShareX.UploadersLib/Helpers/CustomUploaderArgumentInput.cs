﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2018 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using ShareX.HelpersLib;
using System.Collections.Generic;

namespace ShareX.UploadersLib
{
    public class CustomUploaderArgumentInput
    {
        public string Filename { get; set; }
        public string Input { get; set; }

        public CustomUploaderArgumentInput(string filename, string input)
        {
            Filename = filename;
            Input = input;
        }

        public string Parse(string arg)
        {
            NameParser nameParser = new NameParser(NameParserType.Text);
            EscapeHelper escapeHelper = new EscapeHelper();
            arg = escapeHelper.Parse(arg, nameParser.Parse);

            CustomUploaderParser customUploaderParser = new CustomUploaderParser(Filename, Input);
            arg = customUploaderParser.Parse(arg);

            return arg;
        }
    }
}