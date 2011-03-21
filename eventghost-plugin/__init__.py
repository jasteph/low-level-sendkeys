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
import traceback

eg.RegisterPlugin(
    name = "Low Level Sendkeys",
    version = "0.1",
    author = "Teus (based on Bitmonster source)",
    description = (
        "Plugin to interface with low-level-sendkeys application through TCP/IP."
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
    commandType = "Command Type:"
    command = "Command:"
    commandsMapSendKeys = "SENDKEYS"
    commandsMapSendMacro = "SENDMACRO"
    commandsMapLoadFile = "LOADFILE"
    commandsMapSendToTray = "SENDTOTRAY"
    commandsMapRestoreWindow = "RESTOREWINDOW"
    

class LowLevelSendKeysNetworkSender(eg.PluginBase):
    text = Text

    def __init__(self):
        self.AddAction(Command)
        
        
    def __start__(self, host, port):
        self.host = host
        self.port = port
        
        self.socket = None
        #sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        #self.socket = sock
        #sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        #sock.settimeout(2.0)
        #try:
        #    sock.connect((self.host, self.port))
        #    sock.settimeout(1.0)
        #    
        #    print "Connection with low-level-sendkeys established"
        #except:
        #    if eg.debugLevel:
        #        eg.PrintTraceback()
        #    self.PrintError("Network connection failed, reason: " + traceback.print_exc())
        #    sock.close()
        return None
        
    def __stop__(self):
        if self.socket:
           self.socket.close()
           print "Connection with low-level-sendkeys closed."

        self.socket = None

    def Configure(self, host="localhost", port=2005):
        text = self.text
        panel = eg.ConfigPanel()
        hostCtrl = panel.TextCtrl(host)
        portCtrl = panel.SpinIntCtrl(port, max=65535)
        
        st1 = panel.StaticText(text.host)
        st2 = panel.StaticText(text.port)
        eg.EqualizeWidths((st1, st2))
        #eg.EqualizeWidths((st1, st2, st3))
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


    def Send(self, type, message):
        sock = self.socket
        
        try:
            if sock == None:
               print "Connection with low-level-sendkeys was lost, trying to reconnect."
               sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
               self.socket = sock
               sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
               sock.settimeout(2.0)               
               sock.connect((self.host, self.port))
               sock.settimeout(1.0)
               print "Connection with low-level-sendkeys established"

            sock.sendall(type.encode(eg.systemEncoding) + " " + message.encode(eg.systemEncoding) + "\n")

            return sock
        
        except:
            if eg.debugLevel:
                eg.PrintTraceback()
            self.PrintError("Network connection failed, reason: " + traceback.print_exc())
            sock.close()
            self.socket = None
            return None


    #def MapUp(self, sock):
        # tell the server that we are done nicely.
        #sock.sendall("close\n")
        #sock.close()
        
class Command(eg.ActionBase):
    name = "Send Command"
    mode = 0
    
    #def __init__ (self):
    #    self.mode = 0
        
    def __call__(self, displayValue, type, message):
        if type=="": eg.PrintError("Message type must be set!")

        res = self.plugin.Send(eg.ParseString(type), eg.ParseString(message))
        #if res:
        #    eg.event.AddUpFunc(self.plugin.MapUp, res)
        return res
    
    def Configure(self, displayValue="", type="SENDKEYS", message=""):
        panel = eg.ConfigPanel()
        text = Text
        
        #typeCtrl = panel.Choice(text.commandType, text.commandsMap)
        typeCtrl = wx.Choice(panel,-1,size=(200,-1))
        typeCtrl.AppendItems(strings=(text.commandsMapSendKeys,text.commandsMapSendMacro,text.commandsMapLoadFile,text.commandsMapSendToTray,text.commandsMapRestoreWindow))
        typeCtrl.SetSelection(self.mode)

        commandCtrl = panel.TextCtrl(message)
        
        st1 = panel.StaticText(text.commandType)
        st2 = panel.StaticText(text.command)
        eg.EqualizeWidths((st1, st2))

        #box1 = panel.BoxedGroup(text.tcpBox, (st1, addrCtrl), (st2,portCtrl))
        #box2 = panel.BoxedGroup(text.securityBox, (st3, passwordCtrl))
        #box3 = panel.BoxedGroup(text.dataBox, (st4, dataNameCtrl), (st5, dataCtrl))
        
        panel.sizer.Add(typeCtrl, 0, wx.EXPAND)
        panel.sizer.Add(commandCtrl, 0, wx.EXPAND)

        #panel.sizer.AddMany([
        #    (box1, 0, wx.EXPAND),
        #    (box2, 0, wx.EXPAND|wx.TOP, 10),
        #    (box3, 0, wx.EXPAND|wx.TOP, 10),
        #])

        while panel.Affirmed():
            panel.SetResult(
                typeCtrl.GetStringSelection() + ": " + commandCtrl.GetValue(),
                typeCtrl.GetStringSelection(),
                commandCtrl.GetValue()
            )
            self.mode = typeCtrl.GetSelection()
        
#
#self.combo2 = wx.ComboBox(self, -1, value=areaList[0], pos=wx.Point(150, 30),
#
#size=wx.Size(120, 150), choices=areaList)
          
