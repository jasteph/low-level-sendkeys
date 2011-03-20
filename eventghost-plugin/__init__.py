# This file is part of EventGhost.
# Copyright (C) 2005 Lars-Peter Voss <bitmonster@eventghost.org>
# 
# EventGhost is free software; you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation; either version 2 of the License, or
# (at your option) any later version.
# 
# EventGhost is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
# 
# You should have received a copy of the GNU General Public License
# along with EventGhost; if not, write to the Free Software
# Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
#
#
# $LastChangedDate: 2009-07-04 18:37:23 +0200 (Sa, 04 Jul 2009) $
# $LastChangedRevision: 1083 $
# $LastChangedBy: Bitmonster $

import eg

eg.RegisterPlugin(
    name = "Low Level Sendkeys Communication",
    version = "1.0." + "$LastChangedRevision: 1083 $".split()[1],
    author = "Bitmonster",
    description = (
        "Plugin to interface with low-level-sendkeys through TCP/IP."
    ),
    canMultiLoad = True,
    icon = (
        "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABmJLR0QAAAAAAAD5Q7t/"
        "AAAACXBIWXMAAAsSAAALEgHS3X78AAAAB3RJTUUH1gIQFgQOuRVmrAAAAVRJREFUOMud"
        "kjFLw2AQhp+kMQ7+jJpCF+ni1lFEwUXq5g+wgiCCgoNUrG5Oltb2DygGYwUXwbmbg+Li"
        "IhSHhobaora2MZTGoQb5aBLFd/u4u/fuufskApQ92DWAFOEqKSHB1OzMHJoW8w1aloVR"
        "1tNhBmhajPnlQ9/Yzdk2AKEGkiQBkExOAS4wfFcqDwwGg6FBGGv++IiF5DiOZPHcnKDb"
        "+6T9YQs5iscajSd8p2jUqhhlnZfXYfeIMgaA67o/CNF4gsW1C1RVJHKcPlfFJQCaZt23"
        "geKxqqpCYnpSYL2/feIbleuTrZErjCwxEpGpNzp0ew7tjshaKOb8BsgIBnePdXAlz05g"
        "XV1ZEyplWaZQzGUVL8lx+qhv7yM78NRqtYJ30KhVucynAq8AoJ+fBhqUjLKe/uXPZzI7"
        "e/tBBumN9U1s2/at9FiBQANM0+S/UsL4/qIvHUp+5VOP+PAAAAAASUVORK5CYII="
    ),
)

import wx
import socket
from hashlib import md5


class Text:
    host = "Host:"
    port = "Port:"
    tcpBox = "Low Level SendKeys TCP/IP Settings"
#    securityBox = "Security"
    class Map:
        parameterDescription = "Event to send:"
    
    

class NetworkSender(eg.PluginBase):
    text = Text
    
    def __init__(self):
        self.AddAction(Map)
        
        
    def __start__(self, host, port, password):
        self.host = host
        self.port = port
        self.password = password
        
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.socket = sock
        sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        sock.settimeout(2.0)
        try:
            sock.connect((self.host, self.port))
            sock.settimeout(1.0)
        except:
            if eg.debugLevel:
                eg.PrintTraceback()
            sock.close()
            self.PrintError("Network connection failed")
            return None
        
    def __stop__(self):
        if self.socket:
            self.socket.close()
        self.socket = None

    def Configure(self, host="localhost", port=2005):
        text = self.text
        panel = eg.ConfigPanel()
        hostCtrl = panel.TextCtrl(host)
        portCtrl = panel.SpinIntCtrl(port, max=65535)
        
        st1 = panel.StaticText(text.host)
        st2 = panel.StaticText(text.port)
        eg.EqualizeWidths((st1, st2, st3))
        tcpBox = panel.BoxedGroup(
            text.tcpBox,
            (st1, hostCtrl),
            (st2, portCtrl),
        )
#        securityBox = panel.BoxedGroup(
#            text.securityBox,
#            (st3, passwordCtrl),
#        )
        
        panel.sizer.Add(tcpBox, 0, wx.EXPAND)
#        panel.sizer.Add(securityBox, 0, wx.TOP|wx.EXPAND, 10)

        while panel.Affirmed():
            panel.SetResult(
                hostCtrl.GetValue(), 
                portCtrl.GetValue() 
                #passwordCtrl.GetValue()
            )


    def Send(self, eventString, payload=None):
        sock = self.socket
        try:
            sock.sendall(eventString.encode(eg.systemEncoding) + "\n")

            return sock
        
        except:
            if eg.debugLevel:
                eg.PrintTraceback()
            sock.close()
            self.PrintError("NetworkSender failed")
            return None


    #def MapUp(self, sock):
        # tell the server that we are done nicely.
        #sock.sendall("close\n")
        #sock.close()
        
        
        
class Map(eg.ActionWithStringParameter):

    def __call__(self, mesg):
        res = self.plugin.Send(eg.ParseString(mesg))
        #if res:
        #    eg.event.AddUpFunc(self.plugin.MapUp, res)
        return res
          
