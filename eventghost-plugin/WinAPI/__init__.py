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
from ctypes import Structure, c_char_p, c_wchar_p, POINTER, cast, addressof
from eg.WinApi import FindWindow
from eg.WinApi.Dynamic import (
    RegisterWindowMessage,
    SendMessage, 
    DWORD,
    PVOID,
    COPYDATASTRUCT, 
    PCOPYDATASTRUCT, 
    WM_COPYDATA, )
    
import win32con, win32api, win32gui, ctypes, ctypes.wintypes

#class COPYDATASTRUCT(ctypes.Structure):
#    _fields_ = [
#        ('dwData', ctypes.wintypes.LPARAM),
#        ('cbData', ctypes.wintypes.DWORD),
#        ('lpData', ctypes.c_void_p)
#    ]
#PCOPYDATASTRUCT = ctypes.POINTER(COPYDATASTRUCT)


LOW_LEVEL_SENDKEYS_CLASS = "low-levelkeys-main"
    
eg.RegisterPlugin(
    name = "Low Level Sendkeys",
    version = "0.1",
    author = "Teus (based on Bitmonster source)",
    description = (
        "Plugin to interface with low-level-sendkeys application."
    ),
    canMultiLoad = True,
    iconFile = "SendKeys",
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
    
#GlobalHandle = 0

class LowLevelSendKeysNetworkSender(eg.PluginBase):
    text = Text

    def __init__(self):
        self.AddAction(Command)
        
        
    def __start__(self):
        try:
            #global GlobalHandle
            
            message_map = {
                WM_COPYDATA: self.OnCopyData
            }
            wc = win32gui.WNDCLASS()
            wc.lpfnWndProc = message_map
            wc.lpszClassName = 'EventGhostWindowClass'
            hinst = wc.hInstance = win32api.GetModuleHandle(None)
            classAtom = win32gui.RegisterClass(wc)
            GlobalHandle = win32gui.CreateWindow (
                classAtom,
                "LLEVCallBackWnd",
                0,
                0, 
                0,
                win32con.CW_USEDEFAULT, 
                win32con.CW_USEDEFAULT,
                0, 
                0,
                hinst, 
                None
            )
            print GlobalHandle        
        except:
            if eg.debugLevel:
                eg.PrintTraceback()
            self.PrintError("ERROR: " + traceback.print_exc())
            
    @eg.LogIt
    def OnCopyData(self, hwnd, msg, wparam, lparam):
        #print "Handle: " + str(hwnd)
        #print "msg: " + str(msg)
        #print "wparam: " + str(wparam)
        #print "lparam: " + str(lparam)
        pCDS = ctypes.cast(lparam, PCOPYDATASTRUCT)
        #print "dwData: " + str(pCDS.contents.dwData)
        #print "cdData: " + str(pCDS.contents.cbData)
        message =  ctypes.wstring_at(pCDS.contents.lpData)
        index = message.find("#")
        if index < 0:
            print "Invalid command Received"
            return 0
        
        messageFiltrada =  message[index+2:len(message)]
        if messageFiltrada <> "OK":
            self.PrintError(messageFiltrada[7:len(messageFiltrada)])
            return 0
        
        return 1
   
class Command(eg.ActionBase):
    name = "Send Command"
    mode = 0

    def __call__(self, displayValue, type, message):
        if type=="": eg.PrintError("Message type must be set!")

        preset = "LLEVCallBackWnd#1" + type + " " + message
        
        try:
            hwnd = FindWindow(None, LOW_LEVEL_SENDKEYS_CLASS)
        except:
            self.plugin.TriggerEvent("LowLevelSendKeys_NotFound")
            raise self.Exceptions.ProgramNotRunning
            
        cds = COPYDATASTRUCT()
        cds.dwData = 1
        cds.lpData = cast(c_wchar_p(preset), PVOID)
        cds.cbData = (len(preset) + 1)*2
        return SendMessage(hwnd, WM_COPYDATA, 0, addressof(cds))        
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
          
