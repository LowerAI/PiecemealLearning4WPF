# Piecemeal Learning 分散式学习

## BV1sJ41157F7【WPF】怎么做快捷键
+ [原文链接](https://www.bilibili.com/video/BV1sJ41157F7)
+ 绑定原理：元素通过RouteCommand绑定到命令，命令绑定到后台执行函数，也可以在后台的InputBindings中添加KeyBinding来替换“命令绑定到后台执行函数”这一步

## BV157411P7sz WPF模仿Outlook滑动效果
+ [原文链接](https://www.bilibili.com/video/BV157411P7sz)

## BV1HJ411k7jV【WPF】仿win10风格做一个Checkbox
+ [原文链接](https://www.bilibili.com/video/BV1HJ411k7jV)
+ 元素的特效也可以通过属性面板去设置，例如本例中将字符L变成对勾使用了属性页中的转换->水平转换+角度旋转

## SignalRDesktop WPF聊天室应用(ASP.NET Core SignalR)
+ [原文链接](https://www.bilibili.com/video/BV1Q741187Si)
+ 对应的MVC服务端项目叫做SingnalRDemo

## BV1DJ411r7j2【WPF】仿win10做一个侧边弹出式的消息框
+ [原文链接](https://www.bilibili.com/video/BV1DJ411r7j2)

## BV1uJ411n7Zw WPF界面设计教程(Sample1)
+ [原文链接](https://www.bilibili.com/video/BV1uJ411n7Zw)

## BV1XJ411z7QT 【WPF】仿win10系统做一个设置页列表
+ [原文链接](https://www.bilibili.com/video/BV1XJ411z7QT)
+ 不知为何样式触发器不起作用(原因是应设置Border的Backgound透明而不是BorderBrush透明)

## BV1cJ411Y7wW WPF开源图表使用介绍(LiveChart)
+ [原文链接](https://www.bilibili.com/video/BV1cJ411Y7wW)
+ LiveChats图表组件需要同时引用LiveChats包和LiveChats.Wpf包

## BV1UJ411d7zk 【WPF】做一个好看的侧边栏控件
+ [原文链接](https://www.bilibili.com/video/BV1UJ411d7zk)

## BV1XJ411Q7B2 WPF创建Metro磁贴风格应用
+ [原文链接](https://www.bilibili.com/video/BV1XJ411Q7B2)
+ 引用了MaterialDesignTheme和MvvmLight组件

## BV1bJ411D7U3 【WPF】鼠标后面跟个球，跟随运动的做法
+ [原文链接](https://www.bilibili.com/video/BV1bJ411D7U3)

## M3U8 Downloader 模仿WinForm版的The-New-M3U8-Downloader项目制作WPF版的m3u8直播下载器
+ [原文链接](https://github.com/nilaoda/The-New-M3U8-Downloader)

## BV1XJ41127Dp WPF动画基础(模拟心跳)
+ [原文链接](https://www.bilibili.com/video/BV1XJ41127Dp)

## WpfClient WPF客户端
+ 本项目是为了配学习旭老师的[Identity Server 4 原理和实战（完结）](https://www.bilibili.com/video/BV16b411k7yM)中的P5所写

## BV11J411S7Zf 【WPF】自己做一个弹窗控件
+ [原文链接](https://www.bilibili.com/video/BV11J411S7Zf)
+ 再次使用缓动函数实现动画的加减速

## BV1aE411v7F5 WPF界面设计教程之【网易云音乐】
+ [原文链接](https://www.bilibili.com/video/BV1aE411v7F5)

## BV1wb411Y7Xa 【WPF】动画的两种基本的写法
+ [原文链接](https://www.bilibili.com/video/BV1wb411Y7Xa)
+ `RenderTransformOrigin`表示旋转的起始坐标，默认值是元素的左上角，终点是元素的右下角
+ `EasingFunction`表示缓动函数，效果就是旋转开始时的加速和结束时的减速

## BV1aE411i7YQ WPF界面设计教程(Metaril Design)
+ [原文链接](https://www.bilibili.com/video/BV1aE411i7YQ)
+ 要实现元素超出容器之外只需设置边距Margin的值为复数即可

## BV1Cb411y7A3【WPF】仿制一个安卓切换按钮
+ [原文链接](https://www.bilibili.com/video/BV1Cb411y7A3)
+ 矩形的高度只有ToggleButton容器的一半，因此需要转换器MyConverter
+ 绑定容器或者元素自身的属性需要`RelativeSource={RelativeSource Self}`

## BV1HJ411w7eN 【WPF入门视频】Microsoft ToDo 项目实战(合集)
+ [原文链接](https://www.bilibili.com/video/BV1HJ411w7eN)

## BV1ME411i7gC 【WPF】做一个带提示文本的控件
+ [原文链接](https://www.bilibili.com/video/BV1ME411i7gC)
+ 扩展TextBox
+ 通过添加依赖属性TipText来实现文本框水印效果

## BV1mJ411F7zG WPF入门基础教程(合集)
+ [原文链接](https://www.bilibili.com/video/BV1mJ411F7zG)抄写而来

### P2-布局
#### 1.布局的基本原则
+ 一个窗口中只能包含一个元素
+ 不应使用坐标设置元素的位置
+ 大多数情况不应显式定义元素尺寸
+ 支持多元素时，可使用嵌套容器

#### 总结
+ 掌握最为常用的最外层布局容器Grid，StackPanel则为有限的空间内垂直或水平分布元素。
+ WrapPanel相对于StackPanel其自适应空间，可进行自动(换行/换列)处理，适用于自适应布局及元素的个数不固定的情况
+ DockPanel具备4个方向的锚定功能，可适应灵活的非固定的页面布局。

#### P3-样式
+ WPF中的各类控件元素，都可以自由的设置其样式。
+ 诸如：
+ 字体(FontFamily)
+ 字体大小(FontSize)
+ 背景颜色(Background)
+ 字体颜色(Foreground)、边距(Margin)、
+ 水平位置(HorizontalAlignment)、垂直位置(VerticalAlignment)等等
+ 而样式则是组织和重用以上的重要工具。不是使用重复的标记填充XAML，通过Style创建一系列封装所有这些细节的样式。然后通过Style属性应用封装好的样式。这点类似于CSS样式。然而WPF样式的功能更加强大，如控件的模板、触发器等等。

#### P4-触发器
+ Trigger---普通触发器
+ MultiTrigger---多条件触发器
+ EventTrigger---事件触发器

#### P5-控件模板
+ 