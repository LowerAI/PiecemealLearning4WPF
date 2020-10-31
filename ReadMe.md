# Piecemeal Learning 分散式学习
+ 本解决方案的所有项目均为根据B站大佬的视频学习或者现有开源项目模仿而来，目的是学习WPF的开发(界面设计为主)。其中“Mine”目录是我自己模仿开发的项目，“痕迹g”目录是按照痕迹大佬[主页](https://space.bilibili.com/32497462)的视频完全照搬而来，“糖君哒”目录是按照糖君大佬[主页](https://space.bilibili.com/8385275)的视频完全照搬而来。

# BV1Xa411A7Eu【WPF·音频】怎样在调戏电脑的时候播放音效？
+ [原文链接](https://www.bilibili.com/video/BV1Xa411A7Eu)
+ 通过Window.Resource种的样式触发器和Window.Trigger种的事件触发器分别实现音效的播放。

# BV1bi4y1j7Wz【WPF】怎么改写UI渲染的过程？
+ [原文链接](https://www.bilibili.com/video/BV1bi4y1j7Wz)
+ 通过自定义的网格线面板来展示如何自定义UI的渲染来代替系统的默认渲染

# BV14h411X7yt【WPF】键盘秘籍指令的做法
+ [原文链接](https://www.bilibili.com/video/BV14h411X7yt)
+ 怎么做类似于 搓招 指令的东西，使用了队列得先入先出特性，以及数组元素得数量来限制队列存储的按键个数

## BV1Dh411d7w3【WPF】颜色过渡动画怎么做？
+ [原文链接](https://www.bilibili.com/video/BV1Dh411d7w3)
+ 通过事件触发器种的ColorAnimation来控制颜色的渐变，关键点在于`Storyboard.TargetProperty="Background.(SolidColorBrush.Color)"`这句代码

## BV15V411U73V【WPF】教你做一个歌词提词器？
+ [原文链接](https://www.bilibili.com/video/BV15V411U73V)
+ 

## ExcelChart0 c#调用Excel绘制图表
+ [c#调用Excel绘制图表 - 海之殇 - 博客园](https://www.cnblogs.com/fuhai/p/4741877.html)
+ 原以为NetOffice可以免装MS Office来只做Excel图表，结果发现还是依赖于MS Office

## BV1e54y1i7NF【WPF】怎样打飞机
+ [原文链接](https://www.bilibili.com/video/BV1e54y1i7NF)

## BV1M54y1D7AG【WPF】图片对比查看器怎么做
+ [原文链接](https://www.bilibili.com/video/BV1M54y1D7AG)

## BV1AT4y1j7Nh【WPF】怎样做一个侧边导航栏
+ [原文链接](https://www.bilibili.com/video/BV1AT4y1j7Nh)
+ 注意首次看到在style中使用EventSetter来做事件关联
+ 注意左边的动画最重要落实到TranslateTransform上而不是Rectangle上

## BV1mV411B7fi【WPF】Window10 的Loading动画怎么做的？仿一个！
+ [原文链接](https://www.bilibili.com/video/BV1mV411B7fi)
+ 

## BV1fV411B7Fs【WPF】Matrix矩阵变换怎么运用
+ [原文链接](https://www.bilibili.com/video/BV1fV411B7Fs)
+ 一共6个值(M11,M12,M21,M22,OffsetX,OffsetY)，M11表示X轴坐标，M12表示原点不动时宿主偏离x轴的距离(会导致宿主拉伸变形并与X轴形成夹角)，M21表示原点不动时宿主偏离y轴的距离(会导致宿主拉伸变形并与y轴形成夹角)，M22表示Y轴坐标，OffsetX表示宿主的原点偏移x轴的距离，OffsetY表示宿主的原点偏移y轴的距离

## BV1pC4y1h74c【WPF 键盘操控移动】老司机应该怎么开车
+ [原文链接](https://www.bilibili.com/video/BV1pC4y1h74c)
+ 通过旋转变换来控制画布中的小车和坦克进行上下左右的移动
+ 我通过拆分到不同控制键来实现WASD控制小车用上下左右键控制坦克，但必须同时按双方的至少一个键才能保证坦克的移动，如何实现各自独立控制？？

## BV115411W74L WPF模板选择器(项目应用实战)
+ [原文链接](https://www.bilibili.com/video/BV115411W74L)
+ 注意自定义的数据模板类与前端自定义数据模板之间的关联

## BV1hZ4y1u7Wt【WPF】怎么做一个环形进度条
+ [原文链接](https://www.bilibili.com/video/BV1hZ4y1u7Wt)
+ ed是用来画圆形的，注意`EndAngle="{TemplateBinding Value,Converter={StaticResource cvt}}"`这一句就是实现ed和进度条的值进行绑定和转换的
+ 注意通过绑定实现用Slider的值来控制进度条的进度

## BV1zK4y1s78p【WPF】怎么做自转和公转运动
+ [原文链接](https://www.bilibili.com/video/BV1zK4y1s78p)

## BV1Hf4y117G5【WPF】怎样做一个类似win10的动态磁贴
+ [原文链接](https://www.bilibili.com/video/BV1Hf4y117G5)
+ 注意ClipToBounds=true表示超出画布的部分被隐藏
+ 注意动画的目标属性需要初始值

## BV1kT4y1u7gL WPF关键帧动画
+ [原文链接](https://www.bilibili.com/video/BV1kT4y1u7gL)
+ 类似于视频编辑软件中有关键帧和没关键帧的区别

## BV1u5411Y74a【WPF】矩阵 向量 与 跟随旋转
+ [原文链接](https://www.bilibili.com/video/BV1u5411Y74a)
+ 通过反余弦法和旋转矩阵乘法来实现类似坦克锁定目标后炮管与目标始终随动的效果

## BV1ft4y117Bo WPF图表LiveChart性能增强版对比
+ [原文链接](https://www.bilibili.com/video/BV1ft4y117Bo)


## BV13Z4y1p7hE【WPF】按钮波纹点击特效
+ [原文链接](https://www.bilibili.com/video/BV13Z4y1p7hE)

## BV1ik4y1d7yf WPF动画(Animation)
+ [原文链接](https://www.bilibili.com/video/BV1ik4y1d7yf)
+ 注意动画代码的两种执行编写方式：一是通过Storyboard的SetXXX绑定后用Begin启动，一种是通过动画绑定的元素的BeginAnimation方法启动

## BV11V411r75f【WPF】做一个令人讨厌的Loading动画
+ [原文链接](https://www.bilibili.com/video/BV11V411r75f)

## BV1Z7411D7HM【WPF】状态转场动画的做法
+ [原文链接](https://www.bilibili.com/video/BV1Z7411D7HM)
+ 用VisualStateManager管理状态和状态之间的动画
+ 注意`<DiscreteColorKeyFrame Value="Red" KeyTime="0:0:0.5" />`中的`KeyTime`表示从转场开始到切换颜色完成的耗时，`<VisualTransition From="Free" To="Busy" GeneratedDuration="0:0:5">`中的`GeneratedDuration`表示从切换颜色完成到还原为初始颜色的耗时；

## BV1i7411y7VJ WPFCore开源库MqttNet通讯实践
+ [原文链接](https://www.bilibili.com/video/BV1i7411y7VJ)
+ 使用MQTTNet中间件做的聊天

## BV12741117cE【WPF】数字滑动效果
+ [原文链接](https://www.bilibili.com/video/BV12741117cE)
+ 依然是DoubleAnimation和缓动函数的组合，可以用于设计抽奖的核心模块

## BV1gE411c7Zq WPF装饰器(Adorner)
+ [原文链接](https://www.bilibili.com/video/BV1gE411c7Zq)
+ 装饰器效果类似设计UI时选中控件的效果

## BV1D741127X2【WPF】倒计时关键帧
+ [原文链接](https://www.bilibili.com/video/BV1D741127X2)
+ 通过字符串的关键帧动画实现倒计时获取验证码

## BV1uE411N7Bf WPF页面导航(MVVM)
+ [原文链接](https://www.bilibili.com/video/BV1uE411N7Bf)
+ 元素集合中的某项的属性值需要绑定到其父容器的数据源的某个属性或函数(从下往上去绑定)，此时需要RelativeSource

## BV1qE411M7NU WPF转换器(Converter)
+ [原文链接](https://www.bilibili.com/video/BV1qE411M7NU)
+ 转换器：用于某个元素的属性值依赖于其他元素的属性值的变化而变化

## BV1H7411Z7dY【WPF】无边框窗体怎么避坑
+ [原文链接](https://www.bilibili.com/video/)
+ Thumb类，表示可由用户拖动的控件。其主要三个事件分别DragDelta,DragStarted,DragCompleted.
  + DragDelta——当 Thumb 控件具有逻辑焦点和鼠标捕获时，随着鼠标位置更改发生一次或多次。
  + DragStarted——在 Thumb 控件接收逻辑焦点和鼠标捕获时发生。
  + DragCompleted——在 Thumb 控件失去鼠标捕获时发生。

## BV1kE411H7L2 WPF行为(Behavior)
+ [原文链接](https://www.bilibili.com/video/BV1kE411H7L2)
+ .Net Core 3.1.4的WPF中无法集成Behavior类

## BV18E411M7Hi【WPF】怎么做侧滑的弹窗
+ [原文链接](https://www.bilibili.com/video/BV18E411M7Hi)
+ 重点：Frame装载页面、DoubleAnimation动画做弹出/关闭效果、事件触发器绑定动画来触发

## BV1X7411K7fE WPF依赖属性
+ [原文链接](https://www.bilibili.com/video/BV1X7411K7fE)
+ 注意：通过代码实现两个元素的双向绑定时，绑定元素的值总是随被绑定元素的值同步变更，而绑定元素值主动变更时只有该元素失去焦点后被绑定元素的值才会同步变更

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

## M3U8 Downloader
+ 对仿制[M3U8 Downloader项目](https://github.com/nilaoda/The-New-M3U8-Downloader)做二次开发
+ 问题列表：
  + [获取WPF窗体/控件的句柄/当前进程的句柄 - 钱恩基 - 博客园](https://www.cnblogs.com/xiesong/p/6676774.html)
  + [在WPF中调用文件夹浏览/选择对话框_weixin_30659829的博客-CSDN博客_wpf 调用系统文件选择](
https://blog.csdn.net/weixin_30659829/article/details/99957686)
  + [请问WPF 设置 margin 的 value 顺序是上右下左还是上左下右？_百度知道](https://zhidao.baidu.com/question/490781963.html)

### P2-布局
#### 1.布局的基本原则
+ 一个窗口中只能包含一个元素(即根元素)
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