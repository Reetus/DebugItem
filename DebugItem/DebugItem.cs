#region License

// Copyright (C) 2020 Reetus
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using Assistant;
using ClassicAssist.UO.Data;
using ClassicAssist.UO.Network.Packets;

namespace DebugItem
{
    public static class Commands
    {
        public static void DebugItem( int serial, int id, int x, int y, int z, int hue )
        {
            Engine.SendPacketToClient( new SAWorldItem( serial, id, 1, x, y, z, hue ) );
        }

        public class SAWorldItem : BasePacket
        {
            public SAWorldItem( int serial, int itemID, int amount, int x, int y, int z, int hue )
            {
                _writer = new PacketWriter( 26 );
                _writer.Write( (byte) 0xF3 );
                _writer.Write( (short) 1 );
                _writer.Write( (byte) 0 );
                _writer.Write( serial );
                _writer.Write( (short) itemID );
                _writer.Write( (byte) 0 );
                _writer.Write( (short) amount );
                _writer.Write( (short) amount );
                _writer.Write( (short) x );
                _writer.Write( (short) y );
                _writer.Write( (sbyte) z );
                _writer.Write( (byte) 0 );
                _writer.Write( (short) hue );
                _writer.Write( (byte) 0x20 );
                _writer.Write( (short) 0 );
            }
        }
    }
}