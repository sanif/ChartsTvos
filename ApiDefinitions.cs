using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using CoreAnimation;
namespace ChartsBindingProject.tvos
{
	// @interface ChartViewPortJob : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ChartViewPortJob
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xValue:(double)xValue yValue:(double)yValue transformer:(ChartTransformer * _Nonnull)transformer view:(ChartViewBase * _Nonnull)view __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xValue:yValue:transformer:view:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, double xValue, double yValue, ChartTransformer transformer, ChartViewBase view);

		// -(void)doJob;
		[Export("doJob")]
		void DoJob();
	}

	// @interface AnimatedViewPortJob : ChartViewPortJob
	[BaseType(typeof(ChartViewPortJob), Name = "_TtC6Charts19AnimatedViewPortJob")]
	interface AnimatedViewPortJob
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xValue:(double)xValue yValue:(double)yValue transformer:(ChartTransformer * _Nonnull)transformer view:(ChartViewBase * _Nonnull)view xOrigin:(CGFloat)xOrigin yOrigin:(CGFloat)yOrigin duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xValue:yValue:transformer:view:xOrigin:yOrigin:duration:easing:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, double xValue, double yValue, ChartTransformer transformer, ChartViewBase view, nfloat xOrigin, nfloat yOrigin, double duration, [NullAllowed] Func<double, double, double> easing);

		// -(void)doJob;
		[Export("doJob")]
		void DoJob();

		// -(void)start;
		[Export("start")]
		void Start();

		// -(void)stopWithFinish:(BOOL)finish;
		[Export("stopWithFinish:")]
		void StopWithFinish(bool finish);
	}

	// @interface AnimatedMoveViewJob : AnimatedViewPortJob
	[BaseType(typeof(AnimatedViewPortJob), Name = "_TtC6Charts19AnimatedMoveViewJob")]
	interface AnimatedMoveViewJob
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xValue:(double)xValue yValue:(double)yValue transformer:(ChartTransformer * _Nonnull)transformer view:(ChartViewBase * _Nonnull)view xOrigin:(CGFloat)xOrigin yOrigin:(CGFloat)yOrigin duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xValue:yValue:transformer:view:xOrigin:yOrigin:duration:easing:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, double xValue, double yValue, ChartTransformer transformer, ChartViewBase view, nfloat xOrigin, nfloat yOrigin, double duration, [NullAllowed] Func<double, double, double> easing);
	}

	// @interface AnimatedZoomViewJob : AnimatedViewPortJob
	[BaseType(typeof(AnimatedViewPortJob), Name = "_TtC6Charts19AnimatedZoomViewJob")]
	interface AnimatedZoomViewJob
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler transformer:(ChartTransformer * _Nonnull)transformer view:(ChartViewBase * _Nonnull)view yAxis:(ChartYAxis * _Nonnull)yAxis xAxisRange:(double)xAxisRange scaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xOrigin:(CGFloat)xOrigin yOrigin:(CGFloat)yOrigin zoomCenterX:(CGFloat)zoomCenterX zoomCenterY:(CGFloat)zoomCenterY zoomOriginX:(CGFloat)zoomOriginX zoomOriginY:(CGFloat)zoomOriginY duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:transformer:view:yAxis:xAxisRange:scaleX:scaleY:xOrigin:yOrigin:zoomCenterX:zoomCenterY:zoomOriginX:zoomOriginY:duration:easing:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, ChartTransformer transformer, ChartViewBase view, ChartYAxis yAxis, double xAxisRange, nfloat scaleX, nfloat scaleY, nfloat xOrigin, nfloat yOrigin, nfloat zoomCenterX, nfloat zoomCenterY, nfloat zoomOriginX, nfloat zoomOriginY, double duration, [NullAllowed] Func<double, double, double> easing);
	}

	// @interface ChartAnimator : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartAnimator
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		ChartAnimatorDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ChartAnimatorDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(void) updateBlock;
		[NullAllowed, Export("updateBlock", ArgumentSemantic.Copy)]
		Action UpdateBlock { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)(void) stopBlock;
		[NullAllowed, Export("stopBlock", ArgumentSemantic.Copy)]
		Action StopBlock { get; set; }

		// @property (nonatomic) double phaseX;
		[Export("phaseX")]
		double PhaseX { get; set; }

		// @property (nonatomic) double phaseY;
		[Export("phaseY")]
		double PhaseY { get; set; }

		// -(void)stop;
		[Export("stop")]
		void Stop();

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingX:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easingX easingY:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easingY;
		[Export("animateWithXAxisDuration:yAxisDuration:easingX:easingY:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, [NullAllowed] Func<double, double, double> easingX, [NullAllowed] Func<double, double, double> easingY);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingOptionX:(enum ChartEasingOption)easingOptionX easingOptionY:(enum ChartEasingOption)easingOptionY;
		[Export("animateWithXAxisDuration:yAxisDuration:easingOptionX:easingOptionY:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, ChartEasingOption easingOptionX, ChartEasingOption easingOptionY);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithXAxisDuration:yAxisDuration:easing:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithXAxisDuration:yAxisDuration:easingOption:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, ChartEasingOption easingOption);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithXAxisDuration:easing:")]
		void AnimateWithXAxisDuration(double xAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithXAxisDuration:easingOption:")]
		void AnimateWithXAxisDuration(double xAxisDuration, ChartEasingOption easingOption);

		// -(void)animateWithYAxisDuration:(NSTimeInterval)yAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithYAxisDuration:easing:")]
		void AnimateWithYAxisDuration(double yAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithYAxisDuration:(NSTimeInterval)yAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithYAxisDuration:easingOption:")]
		void AnimateWithYAxisDuration(double yAxisDuration, ChartEasingOption easingOption);
	}

	// @protocol ChartAnimatorDelegate
	[Protocol, Model(AutoGeneratedName = true)]
	interface ChartAnimatorDelegate
	{
		// @required -(void)animatorUpdated:(ChartAnimator * _Nonnull)animator;
		[Abstract]
		[Export("animatorUpdated:")]
		void AnimatorUpdated(ChartAnimator animator);

		// @required -(void)animatorStopped:(ChartAnimator * _Nonnull)animator;
		[Abstract]
		[Export("animatorStopped:")]
		void AnimatorStopped(ChartAnimator animator);
	}

	// @interface ChartComponentBase : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartComponentBase
	{
		// @property (nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { get; set; }

		// @property (nonatomic) CGFloat xOffset;
		[Export("xOffset")]
		nfloat XOffset { get; set; }

		// @property (nonatomic) CGFloat yOffset;
		[Export("yOffset")]
		nfloat YOffset { get; set; }

		// @property (readonly, nonatomic) BOOL isEnabled;
		[Export("isEnabled")]
		bool IsEnabled { get; }
	}

	// @interface ChartAxisBase : ChartComponentBase
	[BaseType(typeof(ChartComponentBase))]
	interface ChartAxisBase
	{
		// @property (nonatomic, strong) UIFont * _Nonnull labelFont;
		[Export("labelFont", ArgumentSemantic.Strong)]
		UIFont LabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull labelTextColor;
		[Export("labelTextColor", ArgumentSemantic.Strong)]
		UIColor LabelTextColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull axisLineColor;
		[Export("axisLineColor", ArgumentSemantic.Strong)]
		UIColor AxisLineColor { get; set; }

		// @property (nonatomic) CGFloat axisLineWidth;
		[Export("axisLineWidth")]
		nfloat AxisLineWidth { get; set; }

		// @property (nonatomic) CGFloat axisLineDashPhase;
		[Export("axisLineDashPhase")]
		nfloat AxisLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Null_unspecified axisLineDashLengths;
		[Export("axisLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] AxisLineDashLengths { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull gridColor;
		[Export("gridColor", ArgumentSemantic.Strong)]
		UIColor GridColor { get; set; }

		// @property (nonatomic) CGFloat gridLineWidth;
		[Export("gridLineWidth")]
		nfloat GridLineWidth { get; set; }

		// @property (nonatomic) CGFloat gridLineDashPhase;
		[Export("gridLineDashPhase")]
		nfloat GridLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Null_unspecified gridLineDashLengths;
		[Export("gridLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] GridLineDashLengths { get; set; }

		// @property (nonatomic) CGLineCap gridLineCap;
		[Export("gridLineCap", ArgumentSemantic.Assign)]
		CGLineCap GridLineCap { get; set; }

		// @property (nonatomic) BOOL drawGridLinesEnabled;
		[Export("drawGridLinesEnabled")]
		bool DrawGridLinesEnabled { get; set; }

		// @property (nonatomic) BOOL drawAxisLineEnabled;
		[Export("drawAxisLineEnabled")]
		bool DrawAxisLineEnabled { get; set; }

		// @property (nonatomic) BOOL drawLabelsEnabled;
		[Export("drawLabelsEnabled")]
		bool DrawLabelsEnabled { get; set; }

		// @property (nonatomic) BOOL centerAxisLabelsEnabled;
		[Export("centerAxisLabelsEnabled")]
		bool CenterAxisLabelsEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isCenterAxisLabelsEnabled;
		[Export("isCenterAxisLabelsEnabled")]
		bool IsCenterAxisLabelsEnabled { get; }

		// @property (nonatomic) BOOL drawLimitLinesBehindDataEnabled;
		[Export("drawLimitLinesBehindDataEnabled")]
		bool DrawLimitLinesBehindDataEnabled { get; set; }

		// @property (nonatomic) BOOL drawGridLinesBehindDataEnabled;
		[Export("drawGridLinesBehindDataEnabled")]
		bool DrawGridLinesBehindDataEnabled { get; set; }

		// @property (nonatomic) BOOL gridAntialiasEnabled;
		[Export("gridAntialiasEnabled")]
		bool GridAntialiasEnabled { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull entries;
		[Export("entries", ArgumentSemantic.Copy)]
		NSNumber[] Entries { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull centeredEntries;
		[Export("centeredEntries", ArgumentSemantic.Copy)]
		NSNumber[] CenteredEntries { get; set; }

		// @property (readonly, nonatomic) NSInteger entryCount;
		[Export("entryCount")]
		nint EntryCount { get; }

		// @property (nonatomic) NSInteger decimals;
		[Export("decimals")]
		nint Decimals { get; set; }

		// @property (nonatomic) BOOL granularityEnabled;
		[Export("granularityEnabled")]
		bool GranularityEnabled { get; set; }

		// @property (nonatomic) double granularity;
		[Export("granularity")]
		double Granularity { get; set; }

		// @property (readonly, nonatomic) BOOL isGranularityEnabled;
		[Export("isGranularityEnabled")]
		bool IsGranularityEnabled { get; }

		// @property (nonatomic) BOOL forceLabelsEnabled;
		[Export("forceLabelsEnabled")]
		bool ForceLabelsEnabled { get; set; }

		// -(NSString * _Nonnull)getLongestLabel __attribute__((warn_unused_result));
		[Export("getLongestLabel")]

		string LongestLabel { get; }

		// -(NSString * _Nonnull)getFormattedLabel:(NSInteger)index __attribute__((warn_unused_result));
		[Export("getFormattedLabel:")]
		string GetFormattedLabel(nint index);

		// @property (nonatomic, strong) id<IChartAxisValueFormatter> _Nullable valueFormatter;
		[NullAllowed, Export("valueFormatter", ArgumentSemantic.Strong)]
		IChartAxisValueFormatter ValueFormatter { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawGridLinesEnabled;
		[Export("isDrawGridLinesEnabled")]
		bool IsDrawGridLinesEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawAxisLineEnabled;
		[Export("isDrawAxisLineEnabled")]
		bool IsDrawAxisLineEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawLabelsEnabled;
		[Export("isDrawLabelsEnabled")]
		bool IsDrawLabelsEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawLimitLinesBehindDataEnabled;
		[Export("isDrawLimitLinesBehindDataEnabled")]
		bool IsDrawLimitLinesBehindDataEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawGridLinesBehindDataEnabled;
		[Export("isDrawGridLinesBehindDataEnabled")]
		bool IsDrawGridLinesBehindDataEnabled { get; }

		// @property (nonatomic) double spaceMin;
		[Export("spaceMin")]
		double SpaceMin { get; set; }

		// @property (nonatomic) double spaceMax;
		[Export("spaceMax")]
		double SpaceMax { get; set; }

		// @property (nonatomic) double axisRange;
		[Export("axisRange")]
		double AxisRange { get; set; }

		// @property (nonatomic) NSInteger axisMinLabels;
		[Export("axisMinLabels")]
		nint AxisMinLabels { get; set; }

		// @property (nonatomic) NSInteger axisMaxLabels;
		[Export("axisMaxLabels")]
		nint AxisMaxLabels { get; set; }

		// @property (nonatomic) NSInteger labelCount;
		[Export("labelCount")]
		nint LabelCount { get; set; }

		// -(void)setLabelCount:(NSInteger)count force:(BOOL)force;
		[Export("setLabelCount:force:")]
		void SetLabelCount(nint count, bool force);

		// @property (readonly, nonatomic) BOOL isForceLabelsEnabled;
		[Export("isForceLabelsEnabled")]
		bool IsForceLabelsEnabled { get; }

		// -(void)addLimitLine:(ChartLimitLine * _Nonnull)line;
		[Export("addLimitLine:")]
		void AddLimitLine(ChartLimitLine line);

		// -(void)removeLimitLine:(ChartLimitLine * _Nonnull)line;
		[Export("removeLimitLine:")]
		void RemoveLimitLine(ChartLimitLine line);

		// -(void)removeAllLimitLines;
		[Export("removeAllLimitLines")]
		void RemoveAllLimitLines();

		// @property (readonly, copy, nonatomic) NSArray<ChartLimitLine *> * _Nonnull limitLines;
		[Export("limitLines", ArgumentSemantic.Copy)]
		ChartLimitLine[] LimitLines { get; }

		// -(void)resetCustomAxisMin;
		[Export("resetCustomAxisMin")]
		void ResetCustomAxisMin();

		// @property (readonly, nonatomic) BOOL isAxisMinCustom;
		[Export("isAxisMinCustom")]
		bool IsAxisMinCustom { get; }

		// -(void)resetCustomAxisMax;
		[Export("resetCustomAxisMax")]
		void ResetCustomAxisMax();

		// @property (readonly, nonatomic) BOOL isAxisMaxCustom;
		[Export("isAxisMaxCustom")]
		bool IsAxisMaxCustom { get; }

		// @property (nonatomic) double axisMinimum;
		[Export("axisMinimum")]
		double AxisMinimum { get; set; }

		// @property (nonatomic) double axisMaximum;
		[Export("axisMaximum")]
		double AxisMaximum { get; set; }

		// -(void)calculateWithMin:(double)dataMin max:(double)dataMax;
		[Export("calculateWithMin:max:")]
		void CalculateWithMin(double dataMin, double dataMax);
	}

	// @interface ChartRenderer : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ChartRenderer
	{
		// @property (readonly, nonatomic, strong) ChartViewPortHandler * _Nonnull viewPortHandler;
		[Export("viewPortHandler", ArgumentSemantic.Strong)]
		ChartViewPortHandler ViewPortHandler { get; }

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler);
	}

	// @interface ChartAxisRendererBase : ChartRenderer
	[BaseType(typeof(ChartRenderer))]
	interface ChartAxisRendererBase
	{
		// @property (nonatomic, strong) ChartAxisBase * _Nullable axis;
		[NullAllowed, Export("axis", ArgumentSemantic.Strong)]
		ChartAxisBase Axis { get; set; }

		// @property (nonatomic, strong) ChartTransformer * _Nullable transformer;
		[NullAllowed, Export("transformer", ArgumentSemantic.Strong)]
		ChartTransformer Transformer { get; set; }

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler transformer:(ChartTransformer * _Nullable)transformer axis:(ChartAxisBase * _Nullable)axis __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:transformer:axis:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartTransformer transformer, [NullAllowed] ChartAxisBase axis);

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)renderGridLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderGridLinesWithContext:")]
		unsafe void RenderGridLinesWithContext(CGContext context);

		// -(void)renderAxisLineWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLineWithContext:")]
		unsafe void RenderAxisLineWithContext(CGContext context);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);

		// -(void)computeAxisWithMin:(double)min max:(double)max inverted:(BOOL)inverted;
		[Export("computeAxisWithMin:max:inverted:")]
		void ComputeAxisWithMin(double min, double max, bool inverted);

		// -(void)computeAxisValuesWithMin:(double)min max:(double)max;
		[Export("computeAxisValuesWithMin:max:")]
		void ComputeAxisValuesWithMin(double min, double max);
	}

	// @interface ChartData : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Charts9ChartData")]
	interface ChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// -(instancetype _Nonnull)initWithDataSet:(id<IChartDataSet> _Nullable)dataSet;
		[Export("initWithDataSet:")]
		IntPtr Constructor([NullAllowed] IChartDataSet dataSet);

		// -(void)notifyDataChanged;
		[Export("notifyDataChanged")]
		void NotifyDataChanged();

		// -(void)calcMinMaxYFromX:(double)fromX toX:(double)toX;
		[Export("calcMinMaxYFromX:toX:")]
		void CalcMinMaxYFromX(double fromX, double toX);

		// -(void)calcMinMax;
		[Export("calcMinMax")]
		void CalcMinMax();

		// -(void)calcMinMaxWithEntry:(ChartDataEntry * _Nonnull)e axis:(enum AxisDependency)axis;
		[Export("calcMinMaxWithEntry:axis:")]
		void CalcMinMaxWithEntry(ChartDataEntry e, AxisDependency axis);

		// -(void)calcMinMaxWithDataSet:(id<IChartDataSet> _Nonnull)d;
		[Export("calcMinMaxWithDataSet:")]
		void CalcMinMaxWithDataSet(IChartDataSet d);

		// @property (readonly, nonatomic) NSInteger dataSetCount;
		[Export("dataSetCount")]
		nint DataSetCount { get; }

		// @property (readonly, nonatomic) double yMin;
		[Export("yMin")]
		double YMin { get; }

		// -(double)getYMinWithAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getYMinWithAxis:")]
		double GetYMinWithAxis(AxisDependency axis);

		// @property (readonly, nonatomic) double yMax;
		[Export("yMax")]
		double YMax { get; }

		// -(double)getYMaxWithAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getYMaxWithAxis:")]
		double GetYMaxWithAxis(AxisDependency axis);

		// @property (readonly, nonatomic) double xMin;
		[Export("xMin")]
		double XMin { get; }

		// @property (readonly, nonatomic) double xMax;
		[Export("xMax")]
		double XMax { get; }

		// @property (copy, nonatomic) NSArray<id<IChartDataSet>> * _Nonnull dataSets;
		[Export("dataSets", ArgumentSemantic.Copy)]
		IChartDataSet[] DataSets { get; set; }

		// -(ChartDataEntry * _Nullable)entryForHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("entryForHighlight:")]
		[return: NullAllowed]
		ChartDataEntry EntryForHighlight(ChartHighlight highlight);

		// -(id<IChartDataSet> _Nullable)getDataSetByLabel:(NSString * _Nonnull)label ignorecase:(BOOL)ignorecase __attribute__((warn_unused_result));
		[Export("getDataSetByLabel:ignorecase:")]
		[return: NullAllowed]
		IChartDataSet GetDataSetByLabel(string label, bool ignorecase);

		// -(id<IChartDataSet> _Null_unspecified)getDataSetByIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("getDataSetByIndex:")]
		IChartDataSet GetDataSetByIndex(nint index);

		// -(void)addDataSet:(id<IChartDataSet> _Null_unspecified)dataSet;
		[Export("addDataSet:")]
		void AddDataSet(IChartDataSet dataSet);

		// -(BOOL)removeDataSet:(id<IChartDataSet> _Nonnull)dataSet;
		[Export("removeDataSet:")]
		bool RemoveDataSet(IChartDataSet dataSet);

		// -(BOOL)removeDataSetByIndex:(NSInteger)index;
		[Export("removeDataSetByIndex:")]
		bool RemoveDataSetByIndex(nint index);

		// -(void)addEntry:(ChartDataEntry * _Nonnull)e dataSetIndex:(NSInteger)dataSetIndex;
		[Export("addEntry:dataSetIndex:")]
		void AddEntry(ChartDataEntry e, nint dataSetIndex);

		// -(BOOL)removeEntry:(ChartDataEntry * _Nonnull)entry dataSetIndex:(NSInteger)dataSetIndex;
		[Export("removeEntry:dataSetIndex:")]
		bool RemoveEntry(ChartDataEntry entry, nint dataSetIndex);

		// -(BOOL)removeEntryWithXValue:(double)xValue dataSetIndex:(NSInteger)dataSetIndex;
		[Export("removeEntryWithXValue:dataSetIndex:")]
		bool RemoveEntryWithXValue(double xValue, nint dataSetIndex);

		// -(id<IChartDataSet> _Nullable)getDataSetForEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("getDataSetForEntry:")]
		[return: NullAllowed]
		IChartDataSet GetDataSetForEntry(ChartDataEntry e);

		// -(NSInteger)indexOfDataSet:(id<IChartDataSet> _Nonnull)dataSet __attribute__((warn_unused_result));
		[Export("indexOfDataSet:")]
		nint IndexOfDataSet(IChartDataSet dataSet);

		// -(id<IChartDataSet> _Nullable)getFirstLeftWithDataSets:(NSArray<id<IChartDataSet>> * _Nonnull)dataSets __attribute__((warn_unused_result));
		[Export("getFirstLeftWithDataSets:")]
		[return: NullAllowed]
		IChartDataSet GetFirstLeftWithDataSets(IChartDataSet[] dataSets);

		// -(id<IChartDataSet> _Nullable)getFirstRightWithDataSets:(NSArray<id<IChartDataSet>> * _Nonnull)dataSets __attribute__((warn_unused_result));
		[Export("getFirstRightWithDataSets:")]
		[return: NullAllowed]
		IChartDataSet GetFirstRightWithDataSets(IChartDataSet[] dataSets);

		// -(NSArray<UIColor *> * _Nullable)getColors __attribute__((warn_unused_result));
		[NullAllowed, Export("getColors")]

		UIColor[] Colors { get; }

		// -(void)setValueFormatter:(id<IChartValueFormatter> _Nonnull)formatter;
		[Export("setValueFormatter:")]
		void SetValueFormatter(IChartValueFormatter formatter);

		// -(void)setValueTextColor:(UIColor * _Nonnull)color;
		[Export("setValueTextColor:")]
		void SetValueTextColor(UIColor color);

		// -(void)setValueFont:(UIFont * _Nonnull)font;
		[Export("setValueFont:")]
		void SetValueFont(UIFont font);

		// -(void)setDrawValues:(BOOL)enabled;
		[Export("setDrawValues:")]
		void SetDrawValues(bool enabled);

		// @property (nonatomic) BOOL highlightEnabled;
		[Export("highlightEnabled")]
		bool HighlightEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighlightEnabled;
		[Export("isHighlightEnabled")]
		bool IsHighlightEnabled { get; }

		// -(void)clearValues;
		[Export("clearValues")]
		void ClearValues();

		// -(BOOL)containsWithDataSet:(id<IChartDataSet> _Nonnull)dataSet __attribute__((warn_unused_result));
		[Export("containsWithDataSet:")]
		bool ContainsWithDataSet(IChartDataSet dataSet);

		// @property (readonly, nonatomic) NSInteger entryCount;
		[Export("entryCount")]
		nint EntryCount { get; }

		// @property (readonly, nonatomic, strong) id<IChartDataSet> _Nullable maxEntryCountSet;
		[NullAllowed, Export("maxEntryCountSet", ArgumentSemantic.Strong)]
		IChartDataSet MaxEntryCountSet { get; }

		// @property (copy, nonatomic) NSString * _Nullable accessibilityEntryLabelPrefix;
		[NullAllowed, Export("accessibilityEntryLabelPrefix")]
		string AccessibilityEntryLabelPrefix { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable accessibilityEntryLabelSuffix;
		[NullAllowed, Export("accessibilityEntryLabelSuffix")]
		string AccessibilityEntryLabelSuffix { get; set; }

		// @property (nonatomic) BOOL accessibilityEntryLabelSuffixIsCount;
		[Export("accessibilityEntryLabelSuffixIsCount")]
		bool AccessibilityEntryLabelSuffixIsCount { get; set; }
	}

	// @interface BarLineScatterCandleBubbleChartData : ChartData
	[BaseType(typeof(ChartData), Name = "_TtC6Charts35BarLineScatterCandleBubbleChartData")]
	interface BarLineScatterCandleBubbleChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);
	}

	// @interface BarChartData : BarLineScatterCandleBubbleChartData
	[BaseType(typeof(BarLineScatterCandleBubbleChartData), Name = "_TtC6Charts12BarChartData")]
	interface BarChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// @property (nonatomic) double barWidth;
		[Export("barWidth")]
		double BarWidth { get; set; }

		// -(void)groupBarsFromX:(double)fromX groupSpace:(double)groupSpace barSpace:(double)barSpace;
		[Export("groupBarsFromX:groupSpace:barSpace:")]
		void GroupBarsFromX(double fromX, double groupSpace, double barSpace);

		// -(double)groupWidthWithGroupSpace:(double)groupSpace barSpace:(double)barSpace __attribute__((warn_unused_result));
		[Export("groupWidthWithGroupSpace:barSpace:")]
		double GroupWidthWithGroupSpace(double groupSpace, double barSpace);
	}

	// @interface ChartDataEntryBase : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Charts18ChartDataEntryBase")]
	interface ChartDataEntryBase
	{
		// @property (nonatomic) double y;
		[Export("y")]
		double Y { get; set; }

		// @property (nonatomic) id _Nullable data;
		[NullAllowed, Export("data", ArgumentSemantic.Assign)]
		NSObject Data { get; set; }

		// @property (nonatomic, strong) UIImage * _Nullable icon;
		[NullAllowed, Export("icon", ArgumentSemantic.Strong)]
		UIImage Icon { get; set; }

		// -(instancetype _Nonnull)initWithY:(double)y __attribute__((objc_designated_initializer));
		[Export("initWithY:")]
		[DesignatedInitializer]
		IntPtr Constructor(double y);

		// -(instancetype _Nonnull)initWithY:(double)y data:(id _Nullable)data;
		[Export("initWithY:data:")]
		IntPtr Constructor(double y, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithY:(double)y icon:(UIImage * _Nullable)icon;
		[Export("initWithY:icon:")]
		IntPtr Constructor(double y, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithY:(double)y icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithY:icon:data:")]
		IntPtr Constructor(double y, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }
	}

	// @interface ChartDataEntry : ChartDataEntryBase <NSCopying>
	[BaseType(typeof(ChartDataEntryBase), Name = "_TtC6Charts14ChartDataEntry")]
	interface ChartDataEntry : INSCopying
	{
		// @property (nonatomic) double x;
		[Export("x")]
		double X { get; set; }

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y __attribute__((objc_designated_initializer));
		[Export("initWithX:y:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y data:(id _Nullable)data;
		[Export("initWithX:y:data:")]
		IntPtr Constructor(double x, double y, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y icon:(UIImage * _Nullable)icon;
		[Export("initWithX:y:icon:")]
		IntPtr Constructor(double x, double y, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithX:y:icon:data:")]
		IntPtr Constructor(double x, double y, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface BarChartDataEntry : ChartDataEntry
	[BaseType(typeof(ChartDataEntry), Name = "_TtC6Charts17BarChartDataEntry")]
	interface BarChartDataEntry
	{
		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y __attribute__((objc_designated_initializer));
		[Export("initWithX:y:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y data:(id _Nullable)data;
		[Export("initWithX:y:data:")]
		IntPtr Constructor(double x, double y, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y icon:(UIImage * _Nullable)icon;
		[Export("initWithX:y:icon:")]
		IntPtr Constructor(double x, double y, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithX:y:icon:data:")]
		IntPtr Constructor(double x, double y, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x yValues:(NSArray<NSNumber *> * _Nonnull)yValues __attribute__((objc_designated_initializer));
		[Export("initWithX:yValues:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, NSNumber[] yValues);

		// -(instancetype _Nonnull)initWithX:(double)x yValues:(NSArray<NSNumber *> * _Nonnull)yValues icon:(UIImage * _Nullable)icon;
		[Export("initWithX:yValues:icon:")]
		IntPtr Constructor(double x, NSNumber[] yValues, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithX:(double)x yValues:(NSArray<NSNumber *> * _Nonnull)yValues data:(id _Nullable)data;
		[Export("initWithX:yValues:data:")]
		IntPtr Constructor(double x, NSNumber[] yValues, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x yValues:(NSArray<NSNumber *> * _Nonnull)yValues icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithX:yValues:icon:data:")]
		IntPtr Constructor(double x, NSNumber[] yValues, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// -(double)sumBelowStackIndex:(NSInteger)stackIndex __attribute__((warn_unused_result));
		[Export("sumBelowStackIndex:")]
		double SumBelowStackIndex(nint stackIndex);

		// @property (readonly, nonatomic) double negativeSum;
		[Export("negativeSum")]
		double NegativeSum { get; }

		// @property (readonly, nonatomic) double positiveSum;
		[Export("positiveSum")]
		double PositiveSum { get; }

		// -(void)calcPosNegSum;
		[Export("calcPosNegSum")]
		void CalcPosNegSum();

		// -(void)calcRanges;
		[Export("calcRanges")]
		void CalcRanges();

		// @property (readonly, nonatomic) BOOL isStacked;
		[Export("isStacked")]
		bool IsStacked { get; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable yValues;
		[NullAllowed, Export("yValues", ArgumentSemantic.Copy)]
		NSNumber[] YValues { get; set; }

		// @property (readonly, copy, nonatomic) NSArray<ChartRange *> * _Nullable ranges;
		[NullAllowed, Export("ranges", ArgumentSemantic.Copy)]
		ChartRange[] Ranges { get; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @protocol ChartDataProvider
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts17ChartDataProvider_")]
	interface ChartDataProvider
	{
		// @required @property (readonly, nonatomic) double chartXMin;
		[Abstract]
		[Export("chartXMin")]
		double ChartXMin { get; }

		// @required @property (readonly, nonatomic) double chartXMax;
		[Abstract]
		[Export("chartXMax")]
		double ChartXMax { get; }

		// @required @property (readonly, nonatomic) double chartYMin;
		[Abstract]
		[Export("chartYMin")]
		double ChartYMin { get; }

		// @required @property (readonly, nonatomic) double chartYMax;
		[Abstract]
		[Export("chartYMax")]
		double ChartYMax { get; }

		// @required @property (readonly, nonatomic) CGFloat maxHighlightDistance;
		[Abstract]
		[Export("maxHighlightDistance")]
		nfloat MaxHighlightDistance { get; }

		// @required @property (readonly, nonatomic) double xRange;
		[Abstract]
		[Export("xRange")]
		double XRange { get; }

		// @required @property (readonly, nonatomic) CGPoint centerOffsets;
		[Abstract]
		[Export("centerOffsets")]
		CGPoint CenterOffsets { get; }

		// @required @property (readonly, nonatomic, strong) ChartData * _Nullable data;
		[Abstract]
		[NullAllowed, Export("data", ArgumentSemantic.Strong)]
		ChartData Data { get; }

		// @required @property (readonly, nonatomic) NSInteger maxVisibleCount;
		[Abstract]
		[Export("maxVisibleCount")]
		nint MaxVisibleCount { get; }
	}

	// @protocol BarLineScatterCandleBubbleChartDataProvider <ChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts43BarLineScatterCandleBubbleChartDataProvider_")]
	interface BarLineScatterCandleBubbleChartDataProvider : ChartDataProvider
	{
		// @required -(ChartTransformer * _Nonnull)getTransformerForAxis:(enum AxisDependency)forAxis __attribute__((warn_unused_result));
		[Abstract]
		[Export("getTransformerForAxis:")]
		ChartTransformer GetTransformerForAxis(AxisDependency forAxis);

		// @required -(BOOL)isInvertedWithAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Abstract]
		[Export("isInvertedWithAxis:")]
		bool IsInvertedWithAxis(AxisDependency axis);

		// @required @property (readonly, nonatomic) double lowestVisibleX;
		[Abstract]
		[Export("lowestVisibleX")]
		double LowestVisibleX { get; }

		// @required @property (readonly, nonatomic) double highestVisibleX;
		[Abstract]
		[Export("highestVisibleX")]
		double HighestVisibleX { get; }
	}

	// @protocol BarChartDataProvider <BarLineScatterCandleBubbleChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts20BarChartDataProvider_")]
	interface BarChartDataProvider : BarLineScatterCandleBubbleChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) BarChartData * _Nullable barData;
		[Abstract]
		[NullAllowed, Export("barData", ArgumentSemantic.Strong)]
		BarChartData BarData { get; }

		// @required @property (readonly, nonatomic) BOOL isDrawBarShadowEnabled;
		[Abstract]
		[Export("isDrawBarShadowEnabled")]
		bool IsDrawBarShadowEnabled { get; }

		// @required @property (readonly, nonatomic) BOOL isDrawValueAboveBarEnabled;
		[Abstract]
		[Export("isDrawValueAboveBarEnabled")]
		bool IsDrawValueAboveBarEnabled { get; }

		// @required @property (readonly, nonatomic) BOOL isHighlightFullBarEnabled;
		[Abstract]
		[Export("isHighlightFullBarEnabled")]
		bool IsHighlightFullBarEnabled { get; }
	}

	// @protocol IChartDataSet
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts13IChartDataSet_")]
	interface IChartDataSet
	{
		// @required -(void)notifyDataSetChanged;
		[Abstract]
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// @required -(void)calcMinMax;
		[Abstract]
		[Export("calcMinMax")]
		void CalcMinMax();

		// @required -(void)calcMinMaxYFromX:(double)fromX toX:(double)toX;
		[Abstract]
		[Export("calcMinMaxYFromX:toX:")]
		void CalcMinMaxYFromX(double fromX, double toX);

		// @required @property (readonly, nonatomic) double yMin;
		[Abstract]
		[Export("yMin")]
		double YMin { get; }

		// @required @property (readonly, nonatomic) double yMax;
		[Abstract]
		[Export("yMax")]
		double YMax { get; }

		// @required @property (readonly, nonatomic) double xMin;
		[Abstract]
		[Export("xMin")]
		double XMin { get; }

		// @required @property (readonly, nonatomic) double xMax;
		[Abstract]
		[Export("xMax")]
		double XMax { get; }

		// @required @property (readonly, nonatomic) NSInteger entryCount;
		[Abstract]
		[Export("entryCount")]
		nint EntryCount { get; }

		// @required -(ChartDataEntry * _Nullable)entryForIndex:(NSInteger)i __attribute__((warn_unused_result));
		[Abstract]
		[Export("entryForIndex:")]
		[return: NullAllowed]
		ChartDataEntry EntryForIndex(nint i);

		// @required -(ChartDataEntry * _Nullable)entryForXValue:(double)xValue closestToY:(double)yValue rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Abstract]
		[Export("entryForXValue:closestToY:rounding:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double xValue, double yValue, ChartDataSetRounding rounding);

		// @required -(ChartDataEntry * _Nullable)entryForXValue:(double)xValue closestToY:(double)yValue __attribute__((warn_unused_result));
		[Abstract]
		[Export("entryForXValue:closestToY:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double xValue, double yValue);

		// @required -(NSArray<ChartDataEntry *> * _Nonnull)entriesForXValue:(double)xValue __attribute__((warn_unused_result));
		[Abstract]
		[Export("entriesForXValue:")]
		ChartDataEntry[] EntriesForXValue(double xValue);

		// @required -(NSInteger)entryIndexWithX:(double)xValue closestToY:(double)yValue rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Abstract]
		[Export("entryIndexWithX:closestToY:rounding:")]
		nint EntryIndexWithX(double xValue, double yValue, ChartDataSetRounding rounding);

		// @required -(NSInteger)entryIndexWithEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Abstract]
		[Export("entryIndexWithEntry:")]
		nint EntryIndexWithEntry(ChartDataEntry e);

		// @required -(BOOL)addEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Abstract]
		[Export("addEntry:")]
		bool AddEntry(ChartDataEntry e);

		// @required -(BOOL)addEntryOrdered:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Abstract]
		[Export("addEntryOrdered:")]
		bool AddEntryOrdered(ChartDataEntry e);

		// @required -(BOOL)removeEntry:(ChartDataEntry * _Nonnull)entry __attribute__((warn_unused_result));
		[Abstract]
		[Export("removeEntry:")]
		bool RemoveEntry(ChartDataEntry entry);

		// @required -(BOOL)removeEntryWithIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Abstract]
		[Export("removeEntryWithIndex:")]
		bool RemoveEntryWithIndex(nint index);

		// @required -(BOOL)removeEntryWithX:(double)x __attribute__((warn_unused_result));
		[Abstract]
		[Export("removeEntryWithX:")]
		bool RemoveEntryWithX(double x);

		// @required -(BOOL)removeFirst __attribute__((warn_unused_result));
		[Abstract]
		[Export("removeFirst")]

		bool RemoveFirst { get; }

		// @required -(BOOL)removeLast __attribute__((warn_unused_result));
		[Abstract]
		[Export("removeLast")]

		bool RemoveLast { get; }

		// @required -(BOOL)contains:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Abstract]
		[Export("contains:")]
		bool Contains(ChartDataEntry e);

		// @required -(void)clear;
		[Abstract]
		[Export("clear")]
		void Clear();

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable label;
		[Abstract]
		[NullAllowed, Export("label")]
		string Label { get; }

		// @required @property (readonly, nonatomic) enum AxisDependency axisDependency;
		[Abstract]
		[Export("axisDependency")]
		AxisDependency AxisDependency { get; }

		// @required @property (readonly, copy, nonatomic) NSArray<UIColor *> * _Nonnull valueColors;
		[Abstract]
		[Export("valueColors", ArgumentSemantic.Copy)]
		UIColor[] ValueColors { get; }

		// @required @property (readonly, copy, nonatomic) NSArray<UIColor *> * _Nonnull colors;
		[Abstract]
		[Export("colors", ArgumentSemantic.Copy)]
		UIColor[] Colors { get; }

		// @required -(UIColor * _Nonnull)colorAtIndex:(NSInteger)atIndex __attribute__((warn_unused_result));
		[Abstract]
		[Export("colorAtIndex:")]
		UIColor ColorAtIndex(nint atIndex);

		// @required -(void)resetColors;
		[Abstract]
		[Export("resetColors")]
		void ResetColors();

		// @required -(void)addColor:(UIColor * _Nonnull)color;
		[Abstract]
		[Export("addColor:")]
		void AddColor(UIColor color);

		// @required -(void)setColor:(UIColor * _Nonnull)color;
		[Abstract]
		[Export("setColor:")]
		void SetColor(UIColor color);

		// @required @property (nonatomic) BOOL highlightEnabled;
		[Abstract]
		[Export("highlightEnabled")]
		bool HighlightEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isHighlightEnabled;
		[Abstract]
		[Export("isHighlightEnabled")]
		bool IsHighlightEnabled { get; }

		// @required @property (nonatomic, strong) id<IChartValueFormatter> _Nullable valueFormatter;
		[Abstract]
		[NullAllowed, Export("valueFormatter", ArgumentSemantic.Strong)]
		IChartValueFormatter ValueFormatter { get; set; }

		// @required @property (readonly, nonatomic) BOOL needsFormatter;
		[Abstract]
		[Export("needsFormatter")]
		bool NeedsFormatter { get; }

		// @required @property (nonatomic, strong) UIColor * _Nonnull valueTextColor;
		[Abstract]
		[Export("valueTextColor", ArgumentSemantic.Strong)]
		UIColor ValueTextColor { get; set; }

		// @required -(UIColor * _Nonnull)valueTextColorAt:(NSInteger)index __attribute__((warn_unused_result));
		[Abstract]
		[Export("valueTextColorAt:")]
		UIColor ValueTextColorAt(nint index);

		// @required @property (nonatomic, strong) UIFont * _Nonnull valueFont;
		[Abstract]
		[Export("valueFont", ArgumentSemantic.Strong)]
		UIFont ValueFont { get; set; }

		// @required @property (readonly, nonatomic) enum ChartLegendForm form;
		[Abstract]
		[Export("form")]
		ChartLegendForm Form { get; }

		// @required @property (readonly, nonatomic) CGFloat formSize;
		[Abstract]
		[Export("formSize")]
		nfloat FormSize { get; }

		// @required @property (readonly, nonatomic) CGFloat formLineWidth;
		[Abstract]
		[Export("formLineWidth")]
		nfloat FormLineWidth { get; }

		// @required @property (readonly, nonatomic) CGFloat formLineDashPhase;
		[Abstract]
		[Export("formLineDashPhase")]
		nfloat FormLineDashPhase { get; }

		// @required @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable formLineDashLengths;
		[Abstract]
		[NullAllowed, Export("formLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] FormLineDashLengths { get; }

		// @required @property (nonatomic) BOOL drawValuesEnabled;
		[Abstract]
		[Export("drawValuesEnabled")]
		bool DrawValuesEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawValuesEnabled;
		[Abstract]
		[Export("isDrawValuesEnabled")]
		bool IsDrawValuesEnabled { get; }

		// @required @property (nonatomic) BOOL drawIconsEnabled;
		[Abstract]
		[Export("drawIconsEnabled")]
		bool DrawIconsEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawIconsEnabled;
		[Abstract]
		[Export("isDrawIconsEnabled")]
		bool IsDrawIconsEnabled { get; }

		// @required @property (nonatomic) CGPoint iconsOffset;
		[Abstract]
		[Export("iconsOffset", ArgumentSemantic.Assign)]
		CGPoint IconsOffset { get; set; }

		// @required @property (nonatomic) BOOL visible;
		[Abstract]
		[Export("visible")]
		bool Visible { get; set; }

		// @required @property (readonly, nonatomic) BOOL isVisible;
		[Abstract]
		[Export("isVisible")]
		bool IsVisible { get; }
	}

	// @protocol IBarLineScatterCandleBubbleChartDataSet <IChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts39IBarLineScatterCandleBubbleChartDataSet_")]
	interface IBarLineScatterCandleBubbleChartDataSet : IChartDataSet
	{
		// @required @property (nonatomic, strong) UIColor * _Nonnull highlightColor;
		[Abstract]
		[Export("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }

		// @required @property (nonatomic) CGFloat highlightLineWidth;
		[Abstract]
		[Export("highlightLineWidth")]
		nfloat HighlightLineWidth { get; set; }

		// @required @property (nonatomic) CGFloat highlightLineDashPhase;
		[Abstract]
		[Export("highlightLineDashPhase")]
		nfloat HighlightLineDashPhase { get; set; }

		// @required @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable highlightLineDashLengths;
		[Abstract]
		[NullAllowed, Export("highlightLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] HighlightLineDashLengths { get; set; }
	}

	// @protocol IBarChartDataSet <IBarLineScatterCandleBubbleChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts16IBarChartDataSet_")]
	interface IBarChartDataSet : IBarLineScatterCandleBubbleChartDataSet
	{
		// @required @property (readonly, nonatomic) BOOL isStacked;
		[Abstract]
		[Export("isStacked")]
		bool IsStacked { get; }

		// @required @property (readonly, nonatomic) NSInteger stackSize;
		[Abstract]
		[Export("stackSize")]
		nint StackSize { get; }

		// @required @property (nonatomic, strong) UIColor * _Nonnull barShadowColor;
		[Abstract]
		[Export("barShadowColor", ArgumentSemantic.Strong)]
		UIColor BarShadowColor { get; set; }

		// @required @property (nonatomic) CGFloat barBorderWidth;
		[Abstract]
		[Export("barBorderWidth")]
		nfloat BarBorderWidth { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nonnull barBorderColor;
		[Abstract]
		[Export("barBorderColor", ArgumentSemantic.Strong)]
		UIColor BarBorderColor { get; set; }

		// @required @property (nonatomic) CGFloat highlightAlpha;
		[Abstract]
		[Export("highlightAlpha")]
		nfloat HighlightAlpha { get; set; }

		// @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull stackLabels;
		[Abstract]
		[Export("stackLabels", ArgumentSemantic.Copy)]
		string[] StackLabels { get; set; }
	}

	// @interface ChartBaseDataSet : NSObject <IChartDataSet, NSCopying>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts16ChartBaseDataSet")]
	interface ChartBaseDataSet : IChartDataSet, INSCopying
	{
		// -(instancetype _Nonnull)initWithLabel:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithLabel:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] string label);

		// -(void)notifyDataSetChanged;
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// -(void)calcMinMax;
		[Export("calcMinMax")]
		void CalcMinMax();

		// -(void)calcMinMaxYFromX:(double)fromX toX:(double)toX;
		[Export("calcMinMaxYFromX:toX:")]
		void CalcMinMaxYFromX(double fromX, double toX);

		// @property (readonly, nonatomic) double yMin;
		[Export("yMin")]
		double YMin { get; }

		// @property (readonly, nonatomic) double yMax;
		[Export("yMax")]
		double YMax { get; }

		// @property (readonly, nonatomic) double xMin;
		[Export("xMin")]
		double XMin { get; }

		// @property (readonly, nonatomic) double xMax;
		[Export("xMax")]
		double XMax { get; }

		// @property (readonly, nonatomic) NSInteger entryCount;
		[Export("entryCount")]
		nint EntryCount { get; }

		// -(ChartDataEntry * _Nullable)entryForIndex:(NSInteger)i __attribute__((warn_unused_result));
		[Export("entryForIndex:")]
		[return: NullAllowed]
		ChartDataEntry EntryForIndex(nint i);

		// -(ChartDataEntry * _Nullable)entryForXValue:(double)x closestToY:(double)y rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Export("entryForXValue:closestToY:rounding:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double x, double y, ChartDataSetRounding rounding);

		// -(ChartDataEntry * _Nullable)entryForXValue:(double)x closestToY:(double)y __attribute__((warn_unused_result));
		[Export("entryForXValue:closestToY:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double x, double y);

		// -(NSArray<ChartDataEntry *> * _Nonnull)entriesForXValue:(double)x __attribute__((warn_unused_result));
		[Export("entriesForXValue:")]
		ChartDataEntry[] EntriesForXValue(double x);

		// -(NSInteger)entryIndexWithX:(double)xValue closestToY:(double)y rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Export("entryIndexWithX:closestToY:rounding:")]
		nint EntryIndexWithX(double xValue, double y, ChartDataSetRounding rounding);

		// -(NSInteger)entryIndexWithEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("entryIndexWithEntry:")]
		nint EntryIndexWithEntry(ChartDataEntry e);

		// -(BOOL)addEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("addEntry:")]
		bool AddEntry(ChartDataEntry e);

		// -(BOOL)addEntryOrdered:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("addEntryOrdered:")]
		bool AddEntryOrdered(ChartDataEntry e);

		// -(BOOL)removeEntry:(ChartDataEntry * _Nonnull)entry __attribute__((warn_unused_result));
		[Export("removeEntry:")]
		bool RemoveEntry(ChartDataEntry entry);

		// -(BOOL)removeEntryWithIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("removeEntryWithIndex:")]
		bool RemoveEntryWithIndex(nint index);

		// -(BOOL)removeEntryWithX:(double)x __attribute__((warn_unused_result));
		[Export("removeEntryWithX:")]
		bool RemoveEntryWithX(double x);

		// -(BOOL)removeFirst __attribute__((warn_unused_result));
		[Export("removeFirst")]

		bool RemoveFirst { get; }

		// -(BOOL)removeLast __attribute__((warn_unused_result));
		[Export("removeLast")]

		bool RemoveLast { get; }

		// -(BOOL)contains:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("contains:")]
		bool Contains(ChartDataEntry e);

		// -(void)clear;
		[Export("clear")]
		void Clear();

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull colors;
		[Export("colors", ArgumentSemantic.Copy)]
		UIColor[] Colors { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull valueColors;
		[Export("valueColors", ArgumentSemantic.Copy)]
		UIColor[] ValueColors { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable label;
		[NullAllowed, Export("label")]
		string Label { get; set; }

		// @property (nonatomic) enum AxisDependency axisDependency;
		[Export("axisDependency", ArgumentSemantic.Assign)]
		AxisDependency AxisDependency { get; set; }

		// -(UIColor * _Nonnull)colorAtIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("colorAtIndex:")]
		UIColor ColorAtIndex(nint index);

		// -(void)resetColors;
		[Export("resetColors")]
		void ResetColors();

		// -(void)addColor:(UIColor * _Nonnull)color;
		[Export("addColor:")]
		void AddColor(UIColor color);

		// -(void)setColor:(UIColor * _Nonnull)color;
		[Export("setColor:")]
		void SetColor(UIColor color);

		// -(void)setColor:(UIColor * _Nonnull)color alpha:(CGFloat)alpha;
		[Export("setColor:alpha:")]
		void SetColor(UIColor color, nfloat alpha);

		// -(void)setColors:(NSArray<UIColor *> * _Nonnull)colors alpha:(CGFloat)alpha;
		[Export("setColors:alpha:")]
		void SetColors(UIColor[] colors, nfloat alpha);

		// @property (nonatomic) BOOL highlightEnabled;
		[Export("highlightEnabled")]
		bool HighlightEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighlightEnabled;
		[Export("isHighlightEnabled")]
		bool IsHighlightEnabled { get; }

		// @property (nonatomic, strong) id<IChartValueFormatter> _Nullable valueFormatter;
		[NullAllowed, Export("valueFormatter", ArgumentSemantic.Strong)]
		IChartValueFormatter ValueFormatter { get; set; }

		// @property (readonly, nonatomic) BOOL needsFormatter;
		[Export("needsFormatter")]
		bool NeedsFormatter { get; }

		// @property (nonatomic, strong) UIColor * _Nonnull valueTextColor;
		[Export("valueTextColor", ArgumentSemantic.Strong)]
		UIColor ValueTextColor { get; set; }

		// -(UIColor * _Nonnull)valueTextColorAt:(NSInteger)index __attribute__((warn_unused_result));
		[Export("valueTextColorAt:")]
		UIColor ValueTextColorAt(nint index);

		// @property (nonatomic, strong) UIFont * _Nonnull valueFont;
		[Export("valueFont", ArgumentSemantic.Strong)]
		UIFont ValueFont { get; set; }

		// @property (nonatomic) enum ChartLegendForm form;
		[Export("form", ArgumentSemantic.Assign)]
		ChartLegendForm Form { get; set; }

		// @property (nonatomic) CGFloat formSize;
		[Export("formSize")]
		nfloat FormSize { get; set; }

		// @property (nonatomic) CGFloat formLineWidth;
		[Export("formLineWidth")]
		nfloat FormLineWidth { get; set; }

		// @property (nonatomic) CGFloat formLineDashPhase;
		[Export("formLineDashPhase")]
		nfloat FormLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable formLineDashLengths;
		[NullAllowed, Export("formLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] FormLineDashLengths { get; set; }

		// @property (nonatomic) BOOL drawValuesEnabled;
		[Export("drawValuesEnabled")]
		bool DrawValuesEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawValuesEnabled;
		[Export("isDrawValuesEnabled")]
		bool IsDrawValuesEnabled { get; }

		// @property (nonatomic) BOOL drawIconsEnabled;
		[Export("drawIconsEnabled")]
		bool DrawIconsEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawIconsEnabled;
		[Export("isDrawIconsEnabled")]
		bool IsDrawIconsEnabled { get; }

		// @property (nonatomic) CGPoint iconsOffset;
		[Export("iconsOffset", ArgumentSemantic.Assign)]
		CGPoint IconsOffset { get; set; }

		// @property (nonatomic) BOOL visible;
		[Export("visible")]
		bool Visible { get; set; }

		// @property (readonly, nonatomic) BOOL isVisible;
		[Export("isVisible")]
		bool IsVisible { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull debugDescription;
		[Export("debugDescription")]
		string DebugDescription { get; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface ChartDataSet : ChartBaseDataSet
	[BaseType(typeof(ChartBaseDataSet), Name = "_TtC6Charts12ChartDataSet")]
	interface ChartDataSet
	{
		// -(instancetype _Nonnull)initWithLabel:(NSString * _Nullable)label;
		[Export("initWithLabel:")]
		IntPtr Constructor([NullAllowed] string label);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries;
		[Export("initWithEntries:")]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries);

		// @property (readonly, copy, nonatomic) NSArray<ChartDataEntry *> * _Nonnull entries;
		[Export("entries", ArgumentSemantic.Copy)]
		ChartDataEntry[] Entries { get; }

		// -(void)replaceEntries:(NSArray<ChartDataEntry *> * _Nonnull)entries;
		[Export("replaceEntries:")]
		void ReplaceEntries(ChartDataEntry[] entries);

		// -(void)calcMinMax;
		[Export("calcMinMax")]
		void CalcMinMax();

		// -(void)calcMinMaxYFromX:(double)fromX toX:(double)toX;
		[Export("calcMinMaxYFromX:toX:")]
		void CalcMinMaxYFromX(double fromX, double toX);

		// -(void)calcMinMaxXWithEntry:(ChartDataEntry * _Nonnull)e;
		[Export("calcMinMaxXWithEntry:")]
		void CalcMinMaxXWithEntry(ChartDataEntry e);

		// -(void)calcMinMaxYWithEntry:(ChartDataEntry * _Nonnull)e;
		[Export("calcMinMaxYWithEntry:")]
		void CalcMinMaxYWithEntry(ChartDataEntry e);

		// @property (readonly, nonatomic) double yMin;
		[Export("yMin")]
		double YMin { get; }

		// @property (readonly, nonatomic) double yMax;
		[Export("yMax")]
		double YMax { get; }

		// @property (readonly, nonatomic) double xMin;
		[Export("xMin")]
		double XMin { get; }

		// @property (readonly, nonatomic) double xMax;
		[Export("xMax")]
		double XMax { get; }

		// @property (readonly, nonatomic) NSInteger entryCount __attribute__((deprecated("Use `count` instead")));
		[Export("entryCount")]
		nint EntryCount { get; }

		// -(ChartDataEntry * _Nullable)entryForIndex:(NSInteger)i __attribute__((warn_unused_result)) __attribute__((deprecated("Use `subscript(index:)` instead.")));
		[Export("entryForIndex:")]
		[return: NullAllowed]
		ChartDataEntry EntryForIndex(nint i);

		// -(ChartDataEntry * _Nullable)entryForXValue:(double)xValue closestToY:(double)yValue rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Export("entryForXValue:closestToY:rounding:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double xValue, double yValue, ChartDataSetRounding rounding);

		// -(ChartDataEntry * _Nullable)entryForXValue:(double)xValue closestToY:(double)yValue __attribute__((warn_unused_result));
		[Export("entryForXValue:closestToY:")]
		[return: NullAllowed]
		ChartDataEntry EntryForXValue(double xValue, double yValue);

		// -(NSArray<ChartDataEntry *> * _Nonnull)entriesForXValue:(double)xValue __attribute__((warn_unused_result));
		[Export("entriesForXValue:")]
		ChartDataEntry[] EntriesForXValue(double xValue);

		// -(NSInteger)entryIndexWithX:(double)xValue closestToY:(double)yValue rounding:(enum ChartDataSetRounding)rounding __attribute__((warn_unused_result));
		[Export("entryIndexWithX:closestToY:rounding:")]
		nint EntryIndexWithX(double xValue, double yValue, ChartDataSetRounding rounding);

		// -(NSInteger)entryIndexWithEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result)) __attribute__((deprecated("Use `firstIndex(of:)` or `lastIndex(of:)`")));
		[Export("entryIndexWithEntry:")]
		nint EntryIndexWithEntry(ChartDataEntry e);

		// -(BOOL)addEntry:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result)) __attribute__((deprecated("Use `append(_:)` instead")));
		[Export("addEntry:")]
		bool AddEntry(ChartDataEntry e);

		// -(BOOL)addEntryOrdered:(ChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("addEntryOrdered:")]
		bool AddEntryOrdered(ChartDataEntry e);

		// -(BOOL)removeEntry:(ChartDataEntry * _Nonnull)entry __attribute__((warn_unused_result));
		[Export("removeEntry:")]
		bool RemoveEntry(ChartDataEntry entry);

		// -(BOOL)removeFirst __attribute__((warn_unused_result)) __attribute__((deprecated("Use `func removeFirst() -> ChartDataEntry` instead.")));
		[Export("removeFirst")]

		bool RemoveFirst { get; }

		// -(BOOL)removeLast __attribute__((warn_unused_result)) __attribute__((deprecated("Use `func removeLast() -> ChartDataEntry` instead.")));
		[Export("removeLast")]

		bool RemoveLast { get; }

		// -(void)clear __attribute__((deprecated("Use `removeAll(keepingCapacity:)` instead.")));
		[Export("clear")]
		void Clear();

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface BarLineScatterCandleBubbleChartDataSet : ChartDataSet <IBarLineScatterCandleBubbleChartDataSet>
	[BaseType(typeof(ChartDataSet), Name = "_TtC6Charts38BarLineScatterCandleBubbleChartDataSet")]
	interface BarLineScatterCandleBubbleChartDataSet : IBarLineScatterCandleBubbleChartDataSet
	{
		// @property (nonatomic, strong) UIColor * _Nonnull highlightColor;
		[Export("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }

		// @property (nonatomic) CGFloat highlightLineWidth;
		[Export("highlightLineWidth")]
		nfloat HighlightLineWidth { get; set; }

		// @property (nonatomic) CGFloat highlightLineDashPhase;
		[Export("highlightLineDashPhase")]
		nfloat HighlightLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable highlightLineDashLengths;
		[NullAllowed, Export("highlightLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] HighlightLineDashLengths { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);
	}

	// @interface BarChartDataSet : BarLineScatterCandleBubbleChartDataSet <IBarChartDataSet>
	[BaseType(typeof(BarLineScatterCandleBubbleChartDataSet), Name = "_TtC6Charts15BarChartDataSet")]
	interface BarChartDataSet : IBarChartDataSet
	{
		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// @property (readonly, nonatomic) NSInteger stackSize;
		[Export("stackSize")]
		nint StackSize { get; }

		// @property (readonly, nonatomic) BOOL isStacked;
		[Export("isStacked")]
		bool IsStacked { get; }

		// @property (readonly, nonatomic) NSInteger entryCountStacks;
		[Export("entryCountStacks")]
		nint EntryCountStacks { get; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull stackLabels;
		[Export("stackLabels", ArgumentSemantic.Copy)]
		string[] StackLabels { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull barShadowColor;
		[Export("barShadowColor", ArgumentSemantic.Strong)]
		UIColor BarShadowColor { get; set; }

		// @property (nonatomic) CGFloat barBorderWidth;
		[Export("barBorderWidth")]
		nfloat BarBorderWidth { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull barBorderColor;
		[Export("barBorderColor", ArgumentSemantic.Strong)]
		UIColor BarBorderColor { get; set; }

		// @property (nonatomic) CGFloat highlightAlpha;
		[Export("highlightAlpha")]
		nfloat HighlightAlpha { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface ChartDataRendererBase : ChartRenderer
	[BaseType(typeof(ChartRenderer))]
	interface ChartDataRendererBase
	{
		// @property (copy, nonatomic) NSArray<NSUIAccessibilityElement *> * _Nonnull accessibleChartElements;
		[Export("accessibleChartElements", ArgumentSemantic.Copy)]
		NSUIAccessibilityElement[] AccessibleChartElements { get; set; }

		// @property (readonly, nonatomic, strong) ChartAnimator * _Nonnull animator;
		[Export("animator", ArgumentSemantic.Strong)]
		ChartAnimator Animator { get; }

		// -(instancetype _Nonnull)initWithAnimator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithAnimator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);

		// -(void)initBuffers __attribute__((objc_method_family("none")));
		[Export("initBuffers")]
		void InitBuffers();

		// -(BOOL)isDrawingValuesAllowedWithDataProvider:(id<ChartDataProvider> _Nullable)dataProvider __attribute__((warn_unused_result));
		[Export("isDrawingValuesAllowedWithDataProvider:")]
		bool IsDrawingValuesAllowedWithDataProvider([NullAllowed] ChartDataProvider dataProvider);

		// -(NSUIAccessibilityElement * _Nonnull)createAccessibleHeaderUsingChart:(ChartViewBase * _Nonnull)chart andData:(ChartData * _Nonnull)data withDefaultDescription:(NSString * _Nonnull)defaultDescription __attribute__((warn_unused_result));
		[Export("createAccessibleHeaderUsingChart:andData:withDefaultDescription:")]
		NSUIAccessibilityElement CreateAccessibleHeaderUsingChart(ChartViewBase chart, ChartData data, string defaultDescription);
	}

	// @interface BarLineScatterCandleBubbleChartRenderer : ChartDataRendererBase
	[BaseType(typeof(ChartDataRendererBase))]
	interface BarLineScatterCandleBubbleChartRenderer
	{
		// -(instancetype _Nonnull)initWithAnimator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithAnimator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartAnimator animator, ChartViewPortHandler viewPortHandler);
	}

	// @interface BarChartRenderer : BarLineScatterCandleBubbleChartRenderer
	[BaseType(typeof(BarLineScatterCandleBubbleChartRenderer), Name = "_TtC6Charts16BarChartRenderer")]
	interface BarChartRenderer
	{
		// @property (nonatomic, weak) id<BarChartDataProvider> _Nullable dataProvider;
		[NullAllowed, Export("dataProvider", ArgumentSemantic.Weak)]
		BarChartDataProvider DataProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataProvider:(id<BarChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(BarChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)initBuffers __attribute__((objc_method_family("none")));
		[Export("initBuffers")]
		void InitBuffers();

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<IBarChartDataSet> _Nonnull)dataSet index:(NSInteger)index;
		[Export("drawDataSetWithContext:dataSet:index:")]
		unsafe void DrawDataSetWithContext(CGContext context, IBarChartDataSet dataSet, nint index);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawValueWithContext:(CGContextRef _Nonnull)context value:(NSString * _Nonnull)value xPos:(CGFloat)xPos yPos:(CGFloat)yPos font:(UIFont * _Nonnull)font align:(NSTextAlignment)align color:(UIColor * _Nonnull)color;
		//[Export ("drawValueWithContext:value:xPos:yPos:font:align:color:")]
		//unsafe void DrawValueWithContext (CGContext context, string value, nfloat xPos, nfloat yPos, UIFont font, NSTextAlignment align, UIColor color);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface NSUIView : UIView
	[BaseType(typeof(UIView), Name = "_TtC6Charts8NSUIView")]
	interface NSUIView
	{
		// @property (readonly, nonatomic, strong) CALayer * _Nullable nsuiLayer;
		[NullAllowed, Export("nsuiLayer", ArgumentSemantic.Strong)]
		CALayer NsuiLayer { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder coder);
	}

	// @interface ChartViewBase : NSUIView <ChartAnimatorDelegate, ChartDataProvider>
	[BaseType(typeof(NSUIView), Name = "_TtC6Charts13ChartViewBase")]
	interface ChartViewBase : ChartAnimatorDelegate, ChartDataProvider
	{
		// @property (readonly, nonatomic, strong) ChartXAxis * _Nonnull xAxis;
		[Export("xAxis", ArgumentSemantic.Strong)]
		ChartXAxis XAxis { get; }

		// @property (nonatomic) BOOL dragDecelerationEnabled;
		[Export("dragDecelerationEnabled")]
		bool DragDecelerationEnabled { get; set; }

		// @property (nonatomic, strong) ChartDescription * _Nullable chartDescription;
		[NullAllowed, Export("chartDescription", ArgumentSemantic.Strong)]
		ChartDescription ChartDescription { get; set; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		ChartViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ChartViewDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull noDataText;
		[Export("noDataText")]
		string NoDataText { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull noDataFont;
		[Export("noDataFont", ArgumentSemantic.Strong)]
		UIFont NoDataFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull noDataTextColor;
		[Export("noDataTextColor", ArgumentSemantic.Strong)]
		UIColor NoDataTextColor { get; set; }

		// @property (nonatomic) NSTextAlignment noDataTextAlignment;
		//[Export ("noDataTextAlignment", ArgumentSemantic.Assign)]
		//NSTextAlignment NoDataTextAlignment { get; set; }

		// @property (nonatomic, strong) ChartDataRendererBase * _Nullable renderer;
		[NullAllowed, Export("renderer", ArgumentSemantic.Strong)]
		ChartDataRendererBase Renderer { get; set; }

		// @property (nonatomic, strong) id<IChartHighlighter> _Nullable highlighter;
		[NullAllowed, Export("highlighter", ArgumentSemantic.Strong)]
		IChartHighlighter Highlighter { get; set; }

		// @property (nonatomic) BOOL drawMarkers;
		[Export("drawMarkers")]
		bool DrawMarkers { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawMarkersEnabled;
		[Export("isDrawMarkersEnabled")]
		bool IsDrawMarkersEnabled { get; }

		// @property (nonatomic, strong) id<IChartMarker> _Nullable marker;
		[NullAllowed, Export("marker", ArgumentSemantic.Strong)]
		IChartMarker Marker { get; set; }

		// @property (nonatomic) CGFloat extraTopOffset;
		[Export("extraTopOffset")]
		nfloat ExtraTopOffset { get; set; }

		// @property (nonatomic) CGFloat extraRightOffset;
		[Export("extraRightOffset")]
		nfloat ExtraRightOffset { get; set; }

		// @property (nonatomic) CGFloat extraBottomOffset;
		[Export("extraBottomOffset")]
		nfloat ExtraBottomOffset { get; set; }

		// @property (nonatomic) CGFloat extraLeftOffset;
		[Export("extraLeftOffset")]
		nfloat ExtraLeftOffset { get; set; }

		// -(void)setExtraOffsetsWithLeft:(CGFloat)left top:(CGFloat)top right:(CGFloat)right bottom:(CGFloat)bottom;
		[Export("setExtraOffsetsWithLeft:top:right:bottom:")]
		void SetExtraOffsetsWithLeft(nfloat left, nfloat top, nfloat right, nfloat bottom);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// @property (nonatomic, strong) ChartData * _Nullable data;
		[NullAllowed, Export("data", ArgumentSemantic.Strong)]
		ChartData Data { get; set; }

		// -(void)clear;
		[Export("clear")]
		void Clear();

		// -(void)clearValues;
		[Export("clearValues")]
		void ClearValues();

		// -(BOOL)isEmpty __attribute__((warn_unused_result));
		[Export("isEmpty")]

		bool IsEmpty { get; }

		// -(void)notifyDataSetChanged;
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// -(NSArray * _Nullable)accessibilityChildren __attribute__((warn_unused_result));
		[NullAllowed, Export("accessibilityChildren")]
		NSObject[] AccessibilityChildren { get; }

		// @property (readonly, copy, nonatomic) NSArray<ChartHighlight *> * _Nonnull highlighted;
		[Export("highlighted", ArgumentSemantic.Copy)]
		ChartHighlight[] Highlighted { get; }

		// @property (nonatomic) BOOL highlightPerTapEnabled;
		[Export("highlightPerTapEnabled")]
		bool HighlightPerTapEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighLightPerTapEnabled;
		[Export("isHighLightPerTapEnabled")]
		bool IsHighLightPerTapEnabled { get; }

		// -(BOOL)valuesToHighlight __attribute__((warn_unused_result));
		[Export("valuesToHighlight")]

		bool ValuesToHighlight { get; }

		// -(void)highlightValues:(NSArray<ChartHighlight *> * _Nullable)highs;
		[Export("highlightValues:")]
		void HighlightValues([NullAllowed] ChartHighlight[] highs);

		// -(void)highlightValueWithX:(double)x dataSetIndex:(NSInteger)dataSetIndex dataIndex:(NSInteger)dataIndex;
		[Export("highlightValueWithX:dataSetIndex:dataIndex:")]
		void HighlightValueWithX(double x, nint dataSetIndex, nint dataIndex);

		// -(void)highlightValueWithX:(double)x y:(double)y dataSetIndex:(NSInteger)dataSetIndex dataIndex:(NSInteger)dataIndex;
		[Export("highlightValueWithX:y:dataSetIndex:dataIndex:")]
		void HighlightValueWithX(double x, double y, nint dataSetIndex, nint dataIndex);

		// -(void)highlightValueWithX:(double)x dataSetIndex:(NSInteger)dataSetIndex dataIndex:(NSInteger)dataIndex callDelegate:(BOOL)callDelegate;
		[Export("highlightValueWithX:dataSetIndex:dataIndex:callDelegate:")]
		void HighlightValueWithX(double x, nint dataSetIndex, nint dataIndex, bool callDelegate);

		// -(void)highlightValueWithX:(double)x y:(double)y dataSetIndex:(NSInteger)dataSetIndex dataIndex:(NSInteger)dataIndex callDelegate:(BOOL)callDelegate;
		[Export("highlightValueWithX:y:dataSetIndex:dataIndex:callDelegate:")]
		void HighlightValueWithX(double x, double y, nint dataSetIndex, nint dataIndex, bool callDelegate);

		// -(void)highlightValue:(ChartHighlight * _Nullable)highlight;
		[Export("highlightValue:")]
		void HighlightValue([NullAllowed] ChartHighlight highlight);

		// -(void)highlightValue:(ChartHighlight * _Nullable)highlight callDelegate:(BOOL)callDelegate;
		[Export("highlightValue:callDelegate:")]
		void HighlightValue([NullAllowed] ChartHighlight highlight, bool callDelegate);

		// -(ChartHighlight * _Nullable)getHighlightByTouchPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getHighlightByTouchPoint:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightByTouchPoint(CGPoint pt);

		// @property (nonatomic, strong) ChartHighlight * _Nullable lastHighlighted;
		[NullAllowed, Export("lastHighlighted", ArgumentSemantic.Strong)]
		ChartHighlight LastHighlighted { get; set; }

		// -(CGPoint)getMarkerPositionWithHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("getMarkerPositionWithHighlight:")]
		CGPoint GetMarkerPositionWithHighlight(ChartHighlight highlight);

		// @property (readonly, nonatomic, strong) ChartAnimator * _Null_unspecified chartAnimator;
		[Export("chartAnimator", ArgumentSemantic.Strong)]
		ChartAnimator ChartAnimator { get; }

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingX:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easingX easingY:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easingY;
		[Export("animateWithXAxisDuration:yAxisDuration:easingX:easingY:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, [NullAllowed] Func<double, double, double> easingX, [NullAllowed] Func<double, double, double> easingY);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingOptionX:(enum ChartEasingOption)easingOptionX easingOptionY:(enum ChartEasingOption)easingOptionY;
		[Export("animateWithXAxisDuration:yAxisDuration:easingOptionX:easingOptionY:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, ChartEasingOption easingOptionX, ChartEasingOption easingOptionY);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithXAxisDuration:yAxisDuration:easing:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithXAxisDuration:yAxisDuration:easingOption:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration, ChartEasingOption easingOption);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration yAxisDuration:(NSTimeInterval)yAxisDuration;
		[Export("animateWithXAxisDuration:yAxisDuration:")]
		void AnimateWithXAxisDuration(double xAxisDuration, double yAxisDuration);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithXAxisDuration:easing:")]
		void AnimateWithXAxisDuration(double xAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithXAxisDuration:easingOption:")]
		void AnimateWithXAxisDuration(double xAxisDuration, ChartEasingOption easingOption);

		// -(void)animateWithXAxisDuration:(NSTimeInterval)xAxisDuration;
		[Export("animateWithXAxisDuration:")]
		void AnimateWithXAxisDuration(double xAxisDuration);

		// -(void)animateWithYAxisDuration:(NSTimeInterval)yAxisDuration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("animateWithYAxisDuration:easing:")]
		void AnimateWithYAxisDuration(double yAxisDuration, [NullAllowed] Func<double, double, double> easing);

		// -(void)animateWithYAxisDuration:(NSTimeInterval)yAxisDuration easingOption:(enum ChartEasingOption)easingOption;
		[Export("animateWithYAxisDuration:easingOption:")]
		void AnimateWithYAxisDuration(double yAxisDuration, ChartEasingOption easingOption);

		// -(void)animateWithYAxisDuration:(NSTimeInterval)yAxisDuration;
		[Export("animateWithYAxisDuration:")]
		void AnimateWithYAxisDuration(double yAxisDuration);

		// @property (readonly, nonatomic) double chartYMax;
		[Export("chartYMax")]
		double ChartYMax { get; }

		// @property (readonly, nonatomic) double chartYMin;
		[Export("chartYMin")]
		double ChartYMin { get; }

		// @property (readonly, nonatomic) double chartXMax;
		[Export("chartXMax")]
		double ChartXMax { get; }

		// @property (readonly, nonatomic) double chartXMin;
		[Export("chartXMin")]
		double ChartXMin { get; }

		// @property (readonly, nonatomic) double xRange;
		[Export("xRange")]
		double XRange { get; }

		// @property (readonly, nonatomic) CGPoint midPoint;
		[Export("midPoint")]
		CGPoint MidPoint { get; }

		// @property (readonly, nonatomic) CGPoint centerOffsets;
		[Export("centerOffsets")]
		CGPoint CenterOffsets { get; }

		// @property (readonly, nonatomic, strong) ChartLegend * _Nonnull legend;
		[Export("legend", ArgumentSemantic.Strong)]
		ChartLegend Legend { get; }

		// @property (readonly, nonatomic, strong) ChartLegendRenderer * _Null_unspecified legendRenderer;
		[Export("legendRenderer", ArgumentSemantic.Strong)]
		ChartLegendRenderer LegendRenderer { get; }

		// @property (readonly, nonatomic) CGRect contentRect;
		[Export("contentRect")]
		CGRect ContentRect { get; }

		// @property (readonly, nonatomic, strong) ChartViewPortHandler * _Null_unspecified viewPortHandler;
		[Export("viewPortHandler", ArgumentSemantic.Strong)]
		ChartViewPortHandler ViewPortHandler { get; }

		// -(UIImage * _Nullable)getChartImageWithTransparent:(BOOL)transparent __attribute__((warn_unused_result));
		[Export("getChartImageWithTransparent:")]
		[return: NullAllowed]
		UIImage GetChartImageWithTransparent(bool transparent);

		//// -(void)observeValueForKeyPath:(NSString * _Nullable)keyPath ofObject:(id _Nullable)object change:(NSDictionary<NSKeyValueChangeKey,id> * _Nullable)change context:(void * _Nullable)context;
		//[Export ("observeValueForKeyPath:ofObject:change:context:")]
		//unsafe void ObserveValueForKeyPath ([NullAllowed] string keyPath, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> change, [NullAllowed] void* context);

		// -(void)removeViewportJob:(ChartViewPortJob * _Nonnull)job;
		[Export("removeViewportJob:")]
		void RemoveViewportJob(ChartViewPortJob job);

		// -(void)clearAllViewportJobs;
		[Export("clearAllViewportJobs")]
		void ClearAllViewportJobs();

		// -(void)addViewportJob:(ChartViewPortJob * _Nonnull)job;
		[Export("addViewportJob:")]
		void AddViewportJob(ChartViewPortJob job);

		// @property (readonly, nonatomic) BOOL isDragDecelerationEnabled;
		[Export("isDragDecelerationEnabled")]
		bool IsDragDecelerationEnabled { get; }

		// @property (nonatomic) CGFloat dragDecelerationFrictionCoef;
		[Export("dragDecelerationFrictionCoef")]
		nfloat DragDecelerationFrictionCoef { get; set; }

		// @property (nonatomic) CGFloat maxHighlightDistance;
		[Export("maxHighlightDistance")]
		nfloat MaxHighlightDistance { get; set; }

		// @property (readonly, nonatomic) NSInteger maxVisibleCount;
		[Export("maxVisibleCount")]
		nint MaxVisibleCount { get; }

		// -(void)animatorUpdated:(ChartAnimator * _Nonnull)chartAnimator;
		[Export("animatorUpdated:")]
		void AnimatorUpdated(ChartAnimator chartAnimator);

		// -(void)animatorStopped:(ChartAnimator * _Nonnull)chartAnimator;
		[Export("animatorStopped:")]
		void AnimatorStopped(ChartAnimator chartAnimator);

		// -(void)nsuiTouchesBegan:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesBegan:withEvent:")]
		void NsuiTouchesBegan(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesMoved:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesMoved:withEvent:")]
		void NsuiTouchesMoved(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesEnded:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesEnded:withEvent:")]
		void NsuiTouchesEnded(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesCancelled:(NSSet<UITouch *> * _Nullable)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesCancelled:withEvent:")]
		void NsuiTouchesCancelled([NullAllowed] NSSet<UITouch> touches, [NullAllowed] UIEvent @event);
	}

	// @interface BarLineChartViewBase : ChartViewBase <BarLineScatterCandleBubbleChartDataProvider, UIGestureRecognizerDelegate>
	[BaseType(typeof(ChartViewBase), Name = "_TtC6Charts20BarLineChartViewBase")]
	interface BarLineChartViewBase : BarLineScatterCandleBubbleChartDataProvider, IUIGestureRecognizerDelegate
	{
		// @property (nonatomic, strong) UIColor * _Nonnull gridBackgroundColor;
		[Export("gridBackgroundColor", ArgumentSemantic.Strong)]
		UIColor GridBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (nonatomic) CGFloat borderLineWidth;
		[Export("borderLineWidth")]
		nfloat BorderLineWidth { get; set; }

		// @property (nonatomic) BOOL drawGridBackgroundEnabled;
		[Export("drawGridBackgroundEnabled")]
		bool DrawGridBackgroundEnabled { get; set; }

		// @property (nonatomic) BOOL drawBordersEnabled;
		[Export("drawBordersEnabled")]
		bool DrawBordersEnabled { get; set; }

		// @property (nonatomic) BOOL clipValuesToContentEnabled;
		[Export("clipValuesToContentEnabled")]
		bool ClipValuesToContentEnabled { get; set; }

		// @property (nonatomic) BOOL clipDataToContentEnabled;
		[Export("clipDataToContentEnabled")]
		bool ClipDataToContentEnabled { get; set; }

		// @property (nonatomic) CGFloat minOffset;
		[Export("minOffset")]
		nfloat MinOffset { get; set; }

		// @property (nonatomic) BOOL keepPositionOnRotation;
		[Export("keepPositionOnRotation")]
		bool KeepPositionOnRotation { get; set; }

		// @property (nonatomic, strong) ChartYAxis * _Nonnull leftAxis;
		[Export("leftAxis", ArgumentSemantic.Strong)]
		ChartYAxis LeftAxis { get; set; }

		// @property (nonatomic, strong) ChartYAxis * _Nonnull rightAxis;
		[Export("rightAxis", ArgumentSemantic.Strong)]
		ChartYAxis RightAxis { get; set; }

		// @property (nonatomic, strong) ChartYAxisRenderer * _Nonnull leftYAxisRenderer;
		[Export("leftYAxisRenderer", ArgumentSemantic.Strong)]
		ChartYAxisRenderer LeftYAxisRenderer { get; set; }

		// @property (nonatomic, strong) ChartYAxisRenderer * _Nonnull rightYAxisRenderer;
		[Export("rightYAxisRenderer", ArgumentSemantic.Strong)]
		ChartYAxisRenderer RightYAxisRenderer { get; set; }

		// @property (nonatomic, strong) ChartXAxisRenderer * _Nonnull xAxisRenderer;
		[Export("xAxisRenderer", ArgumentSemantic.Strong)]
		ChartXAxisRenderer XAxisRenderer { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		//// -(void)observeValueForKeyPath:(NSString * _Nullable)keyPath ofObject:(id _Nullable)object change:(NSDictionary<NSKeyValueChangeKey,id> * _Nullable)change context:(void * _Nullable)context;
		//[Export ("observeValueForKeyPath:ofObject:change:context:")]
		//unsafe void ObserveValueForKeyPath ([NullAllowed] string keyPath, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> change, [NullAllowed] void* context);

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// -(void)notifyDataSetChanged;
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// -(void)stopDeceleration;
		[Export("stopDeceleration")]
		void StopDeceleration();

		// -(BOOL)gestureRecognizerShouldBegin:(UIGestureRecognizer * _Nonnull)gestureRecognizer __attribute__((warn_unused_result));
		[Export("gestureRecognizerShouldBegin:")]
		bool GestureRecognizerShouldBegin(UIGestureRecognizer gestureRecognizer);

		// -(BOOL)gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer shouldRecognizeSimultaneouslyWithGestureRecognizer:(UIGestureRecognizer * _Nonnull)otherGestureRecognizer __attribute__((warn_unused_result));
		[Export("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
		bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer);

		// -(void)zoomIn;
		[Export("zoomIn")]
		void ZoomIn();

		// -(void)zoomOut;
		[Export("zoomOut")]
		void ZoomOut();

		// -(void)resetZoom;
		[Export("resetZoom")]
		void ResetZoom();

		// -(void)zoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY x:(CGFloat)x y:(CGFloat)y;
		[Export("zoomWithScaleX:scaleY:x:y:")]
		void ZoomWithScaleX(nfloat scaleX, nfloat scaleY, nfloat x, nfloat y);

		// -(void)zoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis;
		[Export("zoomWithScaleX:scaleY:xValue:yValue:axis:")]
		void ZoomWithScaleX(nfloat scaleX, nfloat scaleY, double xValue, double yValue, AxisDependency axis);

		// -(void)zoomToCenterWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY;
		[Export("zoomToCenterWithScaleX:scaleY:")]
		void ZoomToCenterWithScaleX(nfloat scaleX, nfloat scaleY);

		// -(void)zoomAndCenterViewAnimatedWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("zoomAndCenterViewAnimatedWithScaleX:scaleY:xValue:yValue:axis:duration:easing:")]
		void ZoomAndCenterViewAnimatedWithScaleX(nfloat scaleX, nfloat scaleY, double xValue, double yValue, AxisDependency axis, double duration, [NullAllowed] Func<double, double, double> easing);

		// -(void)zoomAndCenterViewAnimatedWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easingOption:(enum ChartEasingOption)easingOption;
		[Export("zoomAndCenterViewAnimatedWithScaleX:scaleY:xValue:yValue:axis:duration:easingOption:")]
		void ZoomAndCenterViewAnimatedWithScaleX(nfloat scaleX, nfloat scaleY, double xValue, double yValue, AxisDependency axis, double duration, ChartEasingOption easingOption);

		// -(void)zoomAndCenterViewAnimatedWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration;
		[Export("zoomAndCenterViewAnimatedWithScaleX:scaleY:xValue:yValue:axis:duration:")]
		void ZoomAndCenterViewAnimatedWithScaleX(nfloat scaleX, nfloat scaleY, double xValue, double yValue, AxisDependency axis, double duration);

		// -(void)fitScreen;
		[Export("fitScreen")]
		void FitScreen();

		// -(void)setScaleMinima:(CGFloat)scaleX scaleY:(CGFloat)scaleY;
		[Export("setScaleMinima:scaleY:")]
		void SetScaleMinima(nfloat scaleX, nfloat scaleY);

		// @property (readonly, nonatomic) double visibleXRange;
		[Export("visibleXRange")]
		double VisibleXRange { get; }

		// -(void)setVisibleXRangeMaximum:(double)maxXRange;
		[Export("setVisibleXRangeMaximum:")]
		void SetVisibleXRangeMaximum(double maxXRange);

		// -(void)setVisibleXRangeMinimum:(double)minXRange;
		[Export("setVisibleXRangeMinimum:")]
		void SetVisibleXRangeMinimum(double minXRange);

		// -(void)setVisibleXRangeWithMinXRange:(double)minXRange maxXRange:(double)maxXRange;
		[Export("setVisibleXRangeWithMinXRange:maxXRange:")]
		void SetVisibleXRangeWithMinXRange(double minXRange, double maxXRange);

		// -(void)setVisibleYRangeMaximum:(double)maxYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeMaximum:axis:")]
		void SetVisibleYRangeMaximum(double maxYRange, AxisDependency axis);

		// -(void)setVisibleYRangeMinimum:(double)minYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeMinimum:axis:")]
		void SetVisibleYRangeMinimum(double minYRange, AxisDependency axis);

		// -(void)setVisibleYRangeWithMinYRange:(double)minYRange maxYRange:(double)maxYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeWithMinYRange:maxYRange:axis:")]
		void SetVisibleYRangeWithMinYRange(double minYRange, double maxYRange, AxisDependency axis);

		// -(void)moveViewToX:(double)xValue;
		[Export("moveViewToX:")]
		void MoveViewToX(double xValue);

		// -(void)moveViewToY:(double)yValue axis:(enum AxisDependency)axis;
		[Export("moveViewToY:axis:")]
		void MoveViewToY(double yValue, AxisDependency axis);

		// -(void)moveViewToXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis;
		[Export("moveViewToXValue:yValue:axis:")]
		void MoveViewToXValue(double xValue, double yValue, AxisDependency axis);

		// -(void)moveViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("moveViewToAnimatedWithXValue:yValue:axis:duration:easing:")]
		void MoveViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration, [NullAllowed] Func<double, double, double> easing);

		// -(void)moveViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easingOption:(enum ChartEasingOption)easingOption;
		[Export("moveViewToAnimatedWithXValue:yValue:axis:duration:easingOption:")]
		void MoveViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration, ChartEasingOption easingOption);

		// -(void)moveViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration;
		[Export("moveViewToAnimatedWithXValue:yValue:axis:duration:")]
		void MoveViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration);

		// -(void)centerViewToXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis;
		[Export("centerViewToXValue:yValue:axis:")]
		void CenterViewToXValue(double xValue, double yValue, AxisDependency axis);

		// -(void)centerViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("centerViewToAnimatedWithXValue:yValue:axis:duration:easing:")]
		void CenterViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration, [NullAllowed] Func<double, double, double> easing);

		// -(void)centerViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration easingOption:(enum ChartEasingOption)easingOption;
		[Export("centerViewToAnimatedWithXValue:yValue:axis:duration:easingOption:")]
		void CenterViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration, ChartEasingOption easingOption);

		// -(void)centerViewToAnimatedWithXValue:(double)xValue yValue:(double)yValue axis:(enum AxisDependency)axis duration:(NSTimeInterval)duration;
		[Export("centerViewToAnimatedWithXValue:yValue:axis:duration:")]
		void CenterViewToAnimatedWithXValue(double xValue, double yValue, AxisDependency axis, double duration);

		// -(void)setViewPortOffsetsWithLeft:(CGFloat)left top:(CGFloat)top right:(CGFloat)right bottom:(CGFloat)bottom;
		[Export("setViewPortOffsetsWithLeft:top:right:bottom:")]
		void SetViewPortOffsetsWithLeft(nfloat left, nfloat top, nfloat right, nfloat bottom);

		// -(void)resetViewPortOffsets;
		[Export("resetViewPortOffsets")]
		void ResetViewPortOffsets();

		// -(double)getAxisRangeWithAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getAxisRangeWithAxis:")]
		double GetAxisRangeWithAxis(AxisDependency axis);

		// -(CGPoint)getPositionWithEntry:(ChartDataEntry * _Nonnull)e axis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getPositionWithEntry:axis:")]
		CGPoint GetPositionWithEntry(ChartDataEntry e, AxisDependency axis);

		// @property (nonatomic) BOOL dragEnabled;
		[Export("dragEnabled")]
		bool DragEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDragEnabled;
		[Export("isDragEnabled")]
		bool IsDragEnabled { get; }

		// @property (nonatomic) BOOL dragXEnabled;
		[Export("dragXEnabled")]
		bool DragXEnabled { get; set; }

		// @property (nonatomic) BOOL dragYEnabled;
		[Export("dragYEnabled")]
		bool DragYEnabled { get; set; }

		// -(void)setScaleEnabled:(BOOL)enabled;
		[Export("setScaleEnabled:")]
		void SetScaleEnabled(bool enabled);

		// @property (nonatomic) BOOL scaleXEnabled;
		[Export("scaleXEnabled")]
		bool ScaleXEnabled { get; set; }

		// @property (nonatomic) BOOL scaleYEnabled;
		[Export("scaleYEnabled")]
		bool ScaleYEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isScaleXEnabled;
		[Export("isScaleXEnabled")]
		bool IsScaleXEnabled { get; }

		// @property (readonly, nonatomic) BOOL isScaleYEnabled;
		[Export("isScaleYEnabled")]
		bool IsScaleYEnabled { get; }

		// @property (nonatomic) BOOL doubleTapToZoomEnabled;
		[Export("doubleTapToZoomEnabled")]
		bool DoubleTapToZoomEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDoubleTapToZoomEnabled;
		[Export("isDoubleTapToZoomEnabled")]
		bool IsDoubleTapToZoomEnabled { get; }

		// @property (nonatomic) BOOL highlightPerDragEnabled;
		[Export("highlightPerDragEnabled")]
		bool HighlightPerDragEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighlightPerDragEnabled;
		[Export("isHighlightPerDragEnabled")]
		bool IsHighlightPerDragEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawGridBackgroundEnabled;
		[Export("isDrawGridBackgroundEnabled")]
		bool IsDrawGridBackgroundEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawBordersEnabled;
		[Export("isDrawBordersEnabled")]
		bool IsDrawBordersEnabled { get; }

		// -(CGPoint)valueForTouchPointWithPoint:(CGPoint)pt axis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("valueForTouchPointWithPoint:axis:")]
		CGPoint ValueForTouchPointWithPoint(CGPoint pt, AxisDependency axis);

		// -(CGPoint)pixelForValuesWithX:(double)x y:(double)y axis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("pixelForValuesWithX:y:axis:")]
		CGPoint PixelForValuesWithX(double x, double y, AxisDependency axis);

		// -(ChartDataEntry * _Null_unspecified)getEntryByTouchPointWithPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getEntryByTouchPointWithPoint:")]
		ChartDataEntry GetEntryByTouchPointWithPoint(CGPoint pt);

		// -(id<IBarLineScatterCandleBubbleChartDataSet> _Nullable)getDataSetByTouchPointWithPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getDataSetByTouchPointWithPoint:")]
		[return: NullAllowed]
		IBarLineScatterCandleBubbleChartDataSet GetDataSetByTouchPointWithPoint(CGPoint pt);

		// @property (readonly, nonatomic) CGFloat scaleX;
		[Export("scaleX")]
		nfloat ScaleX { get; }

		// @property (readonly, nonatomic) CGFloat scaleY;
		[Export("scaleY")]
		nfloat ScaleY { get; }

		// @property (readonly, nonatomic) BOOL isFullyZoomedOut;
		[Export("isFullyZoomedOut")]
		bool IsFullyZoomedOut { get; }

		// -(ChartYAxis * _Nonnull)getAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getAxis:")]
		ChartYAxis GetAxis(AxisDependency axis);

		// @property (nonatomic) BOOL pinchZoomEnabled;
		[Export("pinchZoomEnabled")]
		bool PinchZoomEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isPinchZoomEnabled;
		[Export("isPinchZoomEnabled")]
		bool IsPinchZoomEnabled { get; }

		// -(void)setDragOffsetX:(CGFloat)offset;
		[Export("setDragOffsetX:")]
		void SetDragOffsetX(nfloat offset);

		// -(void)setDragOffsetY:(CGFloat)offset;
		[Export("setDragOffsetY:")]
		void SetDragOffsetY(nfloat offset);

		// @property (readonly, nonatomic) BOOL hasNoDragOffset;
		[Export("hasNoDragOffset")]
		bool HasNoDragOffset { get; }

		// @property (readonly, nonatomic) double chartYMax;
		[Export("chartYMax")]
		double ChartYMax { get; }

		// @property (readonly, nonatomic) double chartYMin;
		[Export("chartYMin")]
		double ChartYMin { get; }

		// @property (readonly, nonatomic) BOOL isAnyAxisInverted;
		[Export("isAnyAxisInverted")]
		bool IsAnyAxisInverted { get; }

		// @property (nonatomic) BOOL autoScaleMinMaxEnabled;
		[Export("autoScaleMinMaxEnabled")]
		bool AutoScaleMinMaxEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isAutoScaleMinMaxEnabled;
		[Export("isAutoScaleMinMaxEnabled")]
		bool IsAutoScaleMinMaxEnabled { get; }

		// -(void)setYAxisMinWidth:(enum AxisDependency)axis width:(CGFloat)width;
		[Export("setYAxisMinWidth:width:")]
		void SetYAxisMinWidth(AxisDependency axis, nfloat width);

		// -(CGFloat)getYAxisMinWidth:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getYAxisMinWidth:")]
		nfloat GetYAxisMinWidth(AxisDependency axis);

		// -(void)setYAxisMaxWidth:(enum AxisDependency)axis width:(CGFloat)width;
		[Export("setYAxisMaxWidth:width:")]
		void SetYAxisMaxWidth(AxisDependency axis, nfloat width);

		// -(CGFloat)getYAxisMaxWidth:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getYAxisMaxWidth:")]
		nfloat GetYAxisMaxWidth(AxisDependency axis);

		// -(CGFloat)getYAxisWidth:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getYAxisWidth:")]
		nfloat GetYAxisWidth(AxisDependency axis);

		// -(ChartTransformer * _Nonnull)getTransformerForAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getTransformerForAxis:")]
		ChartTransformer GetTransformerForAxis(AxisDependency axis);

		// @property (nonatomic) NSInteger maxVisibleCount;
		[Export("maxVisibleCount")]
		nint MaxVisibleCount { get; set; }

		// -(BOOL)isInvertedWithAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("isInvertedWithAxis:")]
		bool IsInvertedWithAxis(AxisDependency axis);

		// @property (readonly, nonatomic) double lowestVisibleX;
		[Export("lowestVisibleX")]
		double LowestVisibleX { get; }

		// @property (readonly, nonatomic) double highestVisibleX;
		[Export("highestVisibleX")]
		double HighestVisibleX { get; }
	}

	// @interface BarChartView : BarLineChartViewBase <BarChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts12BarChartView")]
	interface BarChartView : BarChartDataProvider
	{
		// -(ChartHighlight * _Nullable)getHighlightByTouchPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getHighlightByTouchPoint:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightByTouchPoint(CGPoint pt);

		// -(CGRect)getBarBoundsWithEntry:(BarChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("getBarBoundsWithEntry:")]
		CGRect GetBarBoundsWithEntry(BarChartDataEntry e);

		// -(void)groupBarsFromX:(double)fromX groupSpace:(double)groupSpace barSpace:(double)barSpace;
		[Export("groupBarsFromX:groupSpace:barSpace:")]
		void GroupBarsFromX(double fromX, double groupSpace, double barSpace);

		// -(void)highlightValueWithX:(double)x dataSetIndex:(NSInteger)dataSetIndex stackIndex:(NSInteger)stackIndex;
		[Export("highlightValueWithX:dataSetIndex:stackIndex:")]
		void HighlightValueWithX(double x, nint dataSetIndex, nint stackIndex);

		// @property (nonatomic) BOOL drawValueAboveBarEnabled;
		[Export("drawValueAboveBarEnabled")]
		bool DrawValueAboveBarEnabled { get; set; }

		// @property (nonatomic) BOOL drawBarShadowEnabled;
		[Export("drawBarShadowEnabled")]
		bool DrawBarShadowEnabled { get; set; }

		// @property (nonatomic) BOOL fitBars;
		[Export("fitBars")]
		bool FitBars { get; set; }

		// @property (nonatomic) BOOL highlightFullBarEnabled;
		[Export("highlightFullBarEnabled")]
		bool HighlightFullBarEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighlightFullBarEnabled;
		[Export("isHighlightFullBarEnabled")]
		bool IsHighlightFullBarEnabled { get; }

		// @property (readonly, nonatomic, strong) BarChartData * _Nullable barData;
		[NullAllowed, Export("barData", ArgumentSemantic.Strong)]
		BarChartData BarData { get; }

		// @property (readonly, nonatomic) BOOL isDrawValueAboveBarEnabled;
		[Export("isDrawValueAboveBarEnabled")]
		bool IsDrawValueAboveBarEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawBarShadowEnabled;
		[Export("isDrawBarShadowEnabled")]
		bool IsDrawBarShadowEnabled { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @protocol IChartHighlighter
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface IChartHighlighter
	{
		// @required -(ChartHighlight * _Nullable)getHighlightWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Abstract]
		[Export("getHighlightWithX:y:")]
		[return: NullAllowed]
		ChartHighlight Y(nfloat x, nfloat y);
	}

	// @interface ChartHighlighter : NSObject <IChartHighlighter>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts16ChartHighlighter")]
	[DisableDefaultCtor]
	interface ChartHighlighter : IChartHighlighter
	{
		// @property (nonatomic, weak) id<ChartDataProvider> _Nullable chart;
		[NullAllowed, Export("chart", ArgumentSemantic.Weak)]
		ChartDataProvider Chart { get; set; }

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);

		// -(ChartHighlight * _Nullable)getHighlightWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightWithX:y:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightWithX(nfloat x, nfloat y);

		// -(CGPoint)getValsForTouchWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getValsForTouchWithX:y:")]
		CGPoint GetValsForTouchWithX(nfloat x, nfloat y);

		// -(ChartHighlight * _Nullable)getHighlightWithXValue:(double)xVal x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightWithXValue:x:y:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightWithXValue(double xVal, nfloat x, nfloat y);

		// -(NSArray<ChartHighlight *> * _Nonnull)getHighlightsWithXValue:(double)xValue x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightsWithXValue:x:y:")]
		ChartHighlight[] GetHighlightsWithXValue(double xValue, nfloat x, nfloat y);
	}

	// @interface BarChartHighlighter : ChartHighlighter
	[BaseType(typeof(ChartHighlighter))]
	interface BarChartHighlighter
	{
		// -(ChartHighlight * _Nullable)getHighlightWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightWithX:y:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightWithX(nfloat x, nfloat y);

		// -(ChartHighlight * _Nullable)getStackedHighlightWithHigh:(ChartHighlight * _Nonnull)high set:(id<IBarChartDataSet> _Nonnull)set xValue:(double)xValue yValue:(double)yValue __attribute__((warn_unused_result));
		[Export("getStackedHighlightWithHigh:set:xValue:yValue:")]
		[return: NullAllowed]
		ChartHighlight GetStackedHighlightWithHigh(ChartHighlight high, IBarChartDataSet set, double xValue, double yValue);

		// -(NSInteger)getClosestStackIndexWithRanges:(NSArray<ChartRange *> * _Nullable)ranges value:(double)value __attribute__((warn_unused_result));
		[Export("getClosestStackIndexWithRanges:value:")]
		nint GetClosestStackIndexWithRanges([NullAllowed] ChartRange[] ranges, double value);

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);
	}

	// @interface BubbleChartData : BarLineScatterCandleBubbleChartData
	[BaseType(typeof(BarLineScatterCandleBubbleChartData), Name = "_TtC6Charts15BubbleChartData")]
	interface BubbleChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// -(void)setHighlightCircleWidth:(CGFloat)width;
		[Export("setHighlightCircleWidth:")]
		void SetHighlightCircleWidth(nfloat width);
	}

	// @interface BubbleChartDataEntry : ChartDataEntry
	[BaseType(typeof(ChartDataEntry), Name = "_TtC6Charts20BubbleChartDataEntry")]
	interface BubbleChartDataEntry
	{
		// @property (nonatomic) CGFloat size;
		[Export("size")]
		nfloat Size { get; set; }

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y size:(CGFloat)size __attribute__((objc_designated_initializer));
		[Export("initWithX:y:size:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y, nfloat size);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y size:(CGFloat)size data:(id _Nullable)data;
		[Export("initWithX:y:size:data:")]
		IntPtr Constructor(double x, double y, nfloat size, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y size:(CGFloat)size icon:(UIImage * _Nullable)icon;
		[Export("initWithX:y:size:icon:")]
		IntPtr Constructor(double x, double y, nfloat size, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y size:(CGFloat)size icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithX:y:size:icon:data:")]
		IntPtr Constructor(double x, double y, nfloat size, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @protocol BubbleChartDataProvider <BarLineScatterCandleBubbleChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts23BubbleChartDataProvider_")]
	interface BubbleChartDataProvider : BarLineScatterCandleBubbleChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) BubbleChartData * _Nullable bubbleData;
		[Abstract]
		[NullAllowed, Export("bubbleData", ArgumentSemantic.Strong)]
		BubbleChartData BubbleData { get; }
	}

	// @protocol IBubbleChartDataSet <IBarLineScatterCandleBubbleChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts19IBubbleChartDataSet_")]
	interface IBubbleChartDataSet : IBarLineScatterCandleBubbleChartDataSet
	{
		// @required @property (readonly, nonatomic) CGFloat maxSize;
		[Abstract]
		[Export("maxSize")]
		nfloat MaxSize { get; }

		// @required @property (readonly, nonatomic) BOOL isNormalizeSizeEnabled;
		[Abstract]
		[Export("isNormalizeSizeEnabled")]
		bool IsNormalizeSizeEnabled { get; }

		// @required @property (nonatomic) CGFloat highlightCircleWidth;
		[Abstract]
		[Export("highlightCircleWidth")]
		nfloat HighlightCircleWidth { get; set; }
	}

	// @interface BubbleChartDataSet : BarLineScatterCandleBubbleChartDataSet <IBubbleChartDataSet>
	[BaseType(typeof(BarLineScatterCandleBubbleChartDataSet), Name = "_TtC6Charts18BubbleChartDataSet")]
	interface BubbleChartDataSet : IBubbleChartDataSet
	{
		// @property (readonly, nonatomic) CGFloat maxSize;
		[Export("maxSize")]
		nfloat MaxSize { get; }

		// @property (nonatomic) BOOL normalizeSizeEnabled;
		[Export("normalizeSizeEnabled")]
		bool NormalizeSizeEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isNormalizeSizeEnabled;
		[Export("isNormalizeSizeEnabled")]
		bool IsNormalizeSizeEnabled { get; }

		// @property (nonatomic) CGFloat highlightCircleWidth;
		[Export("highlightCircleWidth")]
		nfloat HighlightCircleWidth { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);
	}

	// @interface BubbleChartRenderer : BarLineScatterCandleBubbleChartRenderer
	[BaseType(typeof(BarLineScatterCandleBubbleChartRenderer), Name = "_TtC6Charts19BubbleChartRenderer")]
	interface BubbleChartRenderer
	{
		// @property (nonatomic, weak) id<BubbleChartDataProvider> _Nullable dataProvider;
		[NullAllowed, Export("dataProvider", ArgumentSemantic.Weak)]
		BubbleChartDataProvider DataProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataProvider:(id<BubbleChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(BubbleChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<IBubbleChartDataSet> _Nonnull)dataSet dataSetIndex:(NSInteger)dataSetIndex;
		[Export("drawDataSetWithContext:dataSet:dataSetIndex:")]
		unsafe void DrawDataSetWithContext(CGContext context, IBubbleChartDataSet dataSet, nint dataSetIndex);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface BubbleChartView : BarLineChartViewBase <BubbleChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts15BubbleChartView")]
	interface BubbleChartView : BubbleChartDataProvider
	{
		// @property (readonly, nonatomic, strong) BubbleChartData * _Nullable bubbleData;
		[NullAllowed, Export("bubbleData", ArgumentSemantic.Strong)]
		BubbleChartData BubbleData { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface CandleChartData : BarLineScatterCandleBubbleChartData
	[BaseType(typeof(BarLineScatterCandleBubbleChartData), Name = "_TtC6Charts15CandleChartData")]
	interface CandleChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);
	}

	// @interface CandleChartDataEntry : ChartDataEntry
	[BaseType(typeof(ChartDataEntry), Name = "_TtC6Charts20CandleChartDataEntry")]
	interface CandleChartDataEntry
	{
		// @property (nonatomic) double high;
		[Export("high")]
		double High { get; set; }

		// @property (nonatomic) double low;
		[Export("low")]
		double Low { get; set; }

		// @property (nonatomic) double close;
		[Export("close")]
		double Close { get; set; }

		// @property (nonatomic) double open;
		[Export("open")]
		double Open { get; set; }

		// -(instancetype _Nonnull)initWithX:(double)x shadowH:(double)shadowH shadowL:(double)shadowL open:(double)open close:(double)close __attribute__((objc_designated_initializer));
		[Export("initWithX:shadowH:shadowL:open:close:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double shadowH, double shadowL, double open, double close);

		// -(instancetype _Nonnull)initWithX:(double)x shadowH:(double)shadowH shadowL:(double)shadowL open:(double)open close:(double)close icon:(UIImage * _Nullable)icon;
		[Export("initWithX:shadowH:shadowL:open:close:icon:")]
		IntPtr Constructor(double x, double shadowH, double shadowL, double open, double close, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithX:(double)x shadowH:(double)shadowH shadowL:(double)shadowL open:(double)open close:(double)close data:(id _Nullable)data;
		[Export("initWithX:shadowH:shadowL:open:close:data:")]
		IntPtr Constructor(double x, double shadowH, double shadowL, double open, double close, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithX:(double)x shadowH:(double)shadowH shadowL:(double)shadowL open:(double)open close:(double)close icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithX:shadowH:shadowL:open:close:icon:data:")]
		IntPtr Constructor(double x, double shadowH, double shadowL, double open, double close, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// @property (readonly, nonatomic) double shadowRange;
		[Export("shadowRange")]
		double ShadowRange { get; }

		// @property (readonly, nonatomic) double bodyRange;
		[Export("bodyRange")]
		double BodyRange { get; }

		// @property (nonatomic) double y;
		[Export("y")]
		double Y { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @protocol CandleChartDataProvider <BarLineScatterCandleBubbleChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts23CandleChartDataProvider_")]
	interface CandleChartDataProvider : BarLineScatterCandleBubbleChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) CandleChartData * _Nullable candleData;
		[Abstract]
		[NullAllowed, Export("candleData", ArgumentSemantic.Strong)]
		CandleChartData CandleData { get; }
	}

	// @protocol ILineScatterCandleRadarChartDataSet <IBarLineScatterCandleBubbleChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts35ILineScatterCandleRadarChartDataSet_")]
	interface ILineScatterCandleRadarChartDataSet : IBarLineScatterCandleBubbleChartDataSet
	{
		// @required @property (nonatomic) BOOL drawHorizontalHighlightIndicatorEnabled;
		[Abstract]
		[Export("drawHorizontalHighlightIndicatorEnabled")]
		bool DrawHorizontalHighlightIndicatorEnabled { get; set; }

		// @required @property (nonatomic) BOOL drawVerticalHighlightIndicatorEnabled;
		[Abstract]
		[Export("drawVerticalHighlightIndicatorEnabled")]
		bool DrawVerticalHighlightIndicatorEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isHorizontalHighlightIndicatorEnabled;
		[Abstract]
		[Export("isHorizontalHighlightIndicatorEnabled")]
		bool IsHorizontalHighlightIndicatorEnabled { get; }

		// @required @property (readonly, nonatomic) BOOL isVerticalHighlightIndicatorEnabled;
		[Abstract]
		[Export("isVerticalHighlightIndicatorEnabled")]
		bool IsVerticalHighlightIndicatorEnabled { get; }

		// @required -(void)setDrawHighlightIndicators:(BOOL)enabled;
		[Abstract]
		[Export("setDrawHighlightIndicators:")]
		void SetDrawHighlightIndicators(bool enabled);
	}

	// @protocol ICandleChartDataSet <ILineScatterCandleRadarChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts19ICandleChartDataSet_")]
	interface ICandleChartDataSet : ILineScatterCandleRadarChartDataSet
	{
		// @required @property (nonatomic) CGFloat barSpace;
		[Abstract]
		[Export("barSpace")]
		nfloat BarSpace { get; set; }

		// @required @property (nonatomic) BOOL showCandleBar;
		[Abstract]
		[Export("showCandleBar")]
		bool ShowCandleBar { get; set; }

		// @required @property (nonatomic) CGFloat shadowWidth;
		[Abstract]
		[Export("shadowWidth")]
		nfloat ShadowWidth { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable shadowColor;
		[Abstract]
		[NullAllowed, Export("shadowColor", ArgumentSemantic.Strong)]
		UIColor ShadowColor { get; set; }

		// @required @property (nonatomic) BOOL shadowColorSameAsCandle;
		[Abstract]
		[Export("shadowColorSameAsCandle")]
		bool ShadowColorSameAsCandle { get; set; }

		// @required @property (readonly, nonatomic) BOOL isShadowColorSameAsCandle;
		[Abstract]
		[Export("isShadowColorSameAsCandle")]
		bool IsShadowColorSameAsCandle { get; }

		// @required @property (nonatomic, strong) UIColor * _Nullable neutralColor;
		[Abstract]
		[NullAllowed, Export("neutralColor", ArgumentSemantic.Strong)]
		UIColor NeutralColor { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable increasingColor;
		[Abstract]
		[NullAllowed, Export("increasingColor", ArgumentSemantic.Strong)]
		UIColor IncreasingColor { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable decreasingColor;
		[Abstract]
		[NullAllowed, Export("decreasingColor", ArgumentSemantic.Strong)]
		UIColor DecreasingColor { get; set; }

		// @required @property (nonatomic) BOOL increasingFilled;
		[Abstract]
		[Export("increasingFilled")]
		bool IncreasingFilled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isIncreasingFilled;
		[Abstract]
		[Export("isIncreasingFilled")]
		bool IsIncreasingFilled { get; }

		// @required @property (nonatomic) BOOL decreasingFilled;
		[Abstract]
		[Export("decreasingFilled")]
		bool DecreasingFilled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDecreasingFilled;
		[Abstract]
		[Export("isDecreasingFilled")]
		bool IsDecreasingFilled { get; }
	}

	// @interface LineScatterCandleRadarChartDataSet : BarLineScatterCandleBubbleChartDataSet <ILineScatterCandleRadarChartDataSet>
	[BaseType(typeof(BarLineScatterCandleBubbleChartDataSet), Name = "_TtC6Charts34LineScatterCandleRadarChartDataSet")]
	interface LineScatterCandleRadarChartDataSet : ILineScatterCandleRadarChartDataSet
	{
		// @property (nonatomic) BOOL drawHorizontalHighlightIndicatorEnabled;
		[Export("drawHorizontalHighlightIndicatorEnabled")]
		bool DrawHorizontalHighlightIndicatorEnabled { get; set; }

		// @property (nonatomic) BOOL drawVerticalHighlightIndicatorEnabled;
		[Export("drawVerticalHighlightIndicatorEnabled")]
		bool DrawVerticalHighlightIndicatorEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHorizontalHighlightIndicatorEnabled;
		[Export("isHorizontalHighlightIndicatorEnabled")]
		bool IsHorizontalHighlightIndicatorEnabled { get; }

		// @property (readonly, nonatomic) BOOL isVerticalHighlightIndicatorEnabled;
		[Export("isVerticalHighlightIndicatorEnabled")]
		bool IsVerticalHighlightIndicatorEnabled { get; }

		// -(void)setDrawHighlightIndicators:(BOOL)enabled;
		[Export("setDrawHighlightIndicators:")]
		void SetDrawHighlightIndicators(bool enabled);

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);
	}

	// @interface CandleChartDataSet : LineScatterCandleRadarChartDataSet <ICandleChartDataSet>
	[BaseType(typeof(LineScatterCandleRadarChartDataSet), Name = "_TtC6Charts18CandleChartDataSet")]
	interface CandleChartDataSet : ICandleChartDataSet
	{
		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// -(void)calcMinMaxYWithEntry:(ChartDataEntry * _Nonnull)e;
		[Export("calcMinMaxYWithEntry:")]
		void CalcMinMaxYWithEntry(ChartDataEntry e);

		// @property (nonatomic) CGFloat barSpace;
		[Export("barSpace")]
		nfloat BarSpace { get; set; }

		// @property (nonatomic) BOOL showCandleBar;
		[Export("showCandleBar")]
		bool ShowCandleBar { get; set; }

		// @property (nonatomic) CGFloat shadowWidth;
		[Export("shadowWidth")]
		nfloat ShadowWidth { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable shadowColor;
		[NullAllowed, Export("shadowColor", ArgumentSemantic.Strong)]
		UIColor ShadowColor { get; set; }

		// @property (nonatomic) BOOL shadowColorSameAsCandle;
		[Export("shadowColorSameAsCandle")]
		bool ShadowColorSameAsCandle { get; set; }

		// @property (readonly, nonatomic) BOOL isShadowColorSameAsCandle;
		[Export("isShadowColorSameAsCandle")]
		bool IsShadowColorSameAsCandle { get; }

		// @property (nonatomic, strong) UIColor * _Nullable neutralColor;
		[NullAllowed, Export("neutralColor", ArgumentSemantic.Strong)]
		UIColor NeutralColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable increasingColor;
		[NullAllowed, Export("increasingColor", ArgumentSemantic.Strong)]
		UIColor IncreasingColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable decreasingColor;
		[NullAllowed, Export("decreasingColor", ArgumentSemantic.Strong)]
		UIColor DecreasingColor { get; set; }

		// @property (nonatomic) BOOL increasingFilled;
		[Export("increasingFilled")]
		bool IncreasingFilled { get; set; }

		// @property (readonly, nonatomic) BOOL isIncreasingFilled;
		[Export("isIncreasingFilled")]
		bool IsIncreasingFilled { get; }

		// @property (nonatomic) BOOL decreasingFilled;
		[Export("decreasingFilled")]
		bool DecreasingFilled { get; set; }

		// @property (readonly, nonatomic) BOOL isDecreasingFilled;
		[Export("isDecreasingFilled")]
		bool IsDecreasingFilled { get; }
	}

	// @interface LineScatterCandleRadarChartRenderer : BarLineScatterCandleBubbleChartRenderer
	[BaseType(typeof(BarLineScatterCandleBubbleChartRenderer))]
	interface LineScatterCandleRadarChartRenderer
	{
		// -(instancetype _Nonnull)initWithAnimator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithAnimator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawHighlightLinesWithContext:(CGContextRef _Nonnull)context point:(CGPoint)point set:(id<ILineScatterCandleRadarChartDataSet> _Nonnull)set;
		[Export("drawHighlightLinesWithContext:point:set:")]
		unsafe void DrawHighlightLinesWithContext(CGContext context, CGPoint point, ILineScatterCandleRadarChartDataSet set);
	}

	// @interface CandleStickChartRenderer : LineScatterCandleRadarChartRenderer
	[BaseType(typeof(LineScatterCandleRadarChartRenderer), Name = "_TtC6Charts24CandleStickChartRenderer")]
	interface CandleStickChartRenderer
	{
		// @property (nonatomic, weak) id<CandleChartDataProvider> _Nullable dataProvider;
		[NullAllowed, Export("dataProvider", ArgumentSemantic.Weak)]
		CandleChartDataProvider DataProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataProvider:(id<CandleChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(CandleChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<ICandleChartDataSet> _Nonnull)dataSet;
		[Export("drawDataSetWithContext:dataSet:")]
		unsafe void DrawDataSetWithContext(CGContext context, ICandleChartDataSet dataSet);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface CandleStickChartView : BarLineChartViewBase <CandleChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts20CandleStickChartView")]
	interface CandleStickChartView : CandleChartDataProvider
	{
		// @property (readonly, nonatomic, strong) CandleChartData * _Nullable candleData;
		[NullAllowed, Export("candleData", ArgumentSemantic.Strong)]
		CandleChartData CandleData { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface ChartColorTemplates : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC6Charts19ChartColorTemplates")]
	interface ChartColorTemplates
	{
		// +(NSArray<UIColor *> * _Nonnull)liberty __attribute__((warn_unused_result));
		[Static]
		[Export("liberty")]

		UIColor[] Liberty { get; }

		// +(NSArray<UIColor *> * _Nonnull)joyful __attribute__((warn_unused_result));
		[Static]
		[Export("joyful")]

		UIColor[] Joyful { get; }

		// +(NSArray<UIColor *> * _Nonnull)pastel __attribute__((warn_unused_result));
		[Static]
		[Export("pastel")]

		UIColor[] Pastel { get; }

		// +(NSArray<UIColor *> * _Nonnull)colorful __attribute__((warn_unused_result));
		[Static]
		[Export("colorful")]

		UIColor[] Colorful { get; }

		// +(NSArray<UIColor *> * _Nonnull)vordiplom __attribute__((warn_unused_result));
		[Static]
		[Export("vordiplom")]

		UIColor[] Vordiplom { get; }

		// +(NSArray<UIColor *> * _Nonnull)material __attribute__((warn_unused_result));
		[Static]
		[Export("material")]

		UIColor[] Material { get; }

		// +(UIColor * _Nonnull)colorFromString:(NSString * _Nonnull)colorString __attribute__((warn_unused_result));
		[Static]
		[Export("colorFromString:")]
		UIColor ColorFromString(string colorString);
	}

	// @interface Charts_Swift_2573 (ChartDataEntry)
	[Category]
	[BaseType(typeof(ChartDataEntry))]
	interface ChartDataEntry_Charts_Swift_2573
	{
		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
		[Export("isEqual:")]
		bool IsEqual([NullAllowed] NSObject @object);
	}

	// @interface Charts_Swift_2579 (ChartDataEntryBase)
	[Category]
	[BaseType(typeof(ChartDataEntryBase))]
	interface ChartDataEntryBase_Charts_Swift_2579
	{
		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
		[Export("isEqual:")]
		bool IsEqual([NullAllowed] NSObject @object);
	}

	// @interface Charts_Swift_2588 (ChartDataSet)
	[Category]
	[BaseType(typeof(ChartDataSet))]
	interface ChartDataSet_Charts_Swift_2588
	{
		// -(void)removeAllWithKeepingCapacity:(BOOL)keepCapacity;
		[Export("removeAllWithKeepingCapacity:")]
		void RemoveAllWithKeepingCapacity(bool keepCapacity);
	}

	// @interface Charts_Swift_2593 (ChartDataSet)
	[Category]
	[BaseType(typeof(ChartDataSet))]
	interface ChartDataSet_Charts_Swift_2593
	{
		// -(ChartDataEntry * _Nonnull)objectAtIndexedSubscript:(NSInteger)position __attribute__((warn_unused_result));
		[Export("objectAtIndexedSubscript:")]
		ChartDataEntry ObjectAtIndexedSubscript(nint position);

		// -(void)setObject:(ChartDataEntry * _Nonnull)newValue atIndexedSubscript:(NSInteger)position;
		[Export("setObject:atIndexedSubscript:")]
		void SetObject(ChartDataEntry newValue, nint position);
	}

	// @interface ChartLimitLine : ChartComponentBase
	[BaseType(typeof(ChartComponentBase), Name = "_TtC6Charts14ChartLimitLine")]
	interface ChartLimitLine
	{
		// @property (nonatomic) double limit;
		[Export("limit")]
		double Limit { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull lineColor;
		[Export("lineColor", ArgumentSemantic.Strong)]
		UIColor LineColor { get; set; }

		// @property (nonatomic) CGFloat lineDashPhase;
		[Export("lineDashPhase")]
		nfloat LineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineDashLengths;
		[NullAllowed, Export("lineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] LineDashLengths { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull valueTextColor;
		[Export("valueTextColor", ArgumentSemantic.Strong)]
		UIColor ValueTextColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull valueFont;
		[Export("valueFont", ArgumentSemantic.Strong)]
		UIFont ValueFont { get; set; }

		// @property (nonatomic) BOOL drawLabelEnabled;
		[Export("drawLabelEnabled")]
		bool DrawLabelEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull label;
		[Export("label")]
		string Label { get; set; }

		// @property (nonatomic) enum ChartLimitLabelPosition labelPosition;
		[Export("labelPosition", ArgumentSemantic.Assign)]
		ChartLimitLabelPosition LabelPosition { get; set; }

		// -(instancetype _Nonnull)initWithLimit:(double)limit __attribute__((objc_designated_initializer));
		[Export("initWithLimit:")]
		[DesignatedInitializer]
		IntPtr Constructor(double limit);

		// -(instancetype _Nonnull)initWithLimit:(double)limit label:(NSString * _Nonnull)label __attribute__((objc_designated_initializer));
		[Export("initWithLimit:label:")]
		[DesignatedInitializer]
		IntPtr Constructor(double limit, string label);

		// @property (nonatomic) CGFloat lineWidth;
		[Export("lineWidth")]
		nfloat LineWidth { get; set; }
	}

	// @protocol ChartViewDelegate
	[Protocol(Name = "_TtP6Charts17ChartViewDelegate_"), Model(AutoGeneratedName = true)]
	interface ChartViewDelegate
	{
		// @optional -(void)chartValueSelected:(ChartViewBase * _Nonnull)chartView entry:(ChartDataEntry * _Nonnull)entry highlight:(ChartHighlight * _Nonnull)highlight;
		[Export("chartValueSelected:entry:highlight:")]
		void ChartValueSelected(ChartViewBase chartView, ChartDataEntry entry, ChartHighlight highlight);

		// @optional -(void)chartViewDidEndPanning:(ChartViewBase * _Nonnull)chartView;
		[Export("chartViewDidEndPanning:")]
		void ChartViewDidEndPanning(ChartViewBase chartView);

		// @optional -(void)chartValueNothingSelected:(ChartViewBase * _Nonnull)chartView;
		[Export("chartValueNothingSelected:")]
		void ChartValueNothingSelected(ChartViewBase chartView);

		// @optional -(void)chartScaled:(ChartViewBase * _Nonnull)chartView scaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY;
		[Export("chartScaled:scaleX:scaleY:")]
		void ChartScaled(ChartViewBase chartView, nfloat scaleX, nfloat scaleY);

		// @optional -(void)chartTranslated:(ChartViewBase * _Nonnull)chartView dX:(CGFloat)dX dY:(CGFloat)dY;
		[Export("chartTranslated:dX:dY:")]
		void ChartTranslated(ChartViewBase chartView, nfloat dX, nfloat dY);

		// @optional -(void)chartView:(ChartViewBase * _Nonnull)chartView animatorDidStop:(ChartAnimator * _Nonnull)animator;
		[Export("chartView:animatorDidStop:")]
		void ChartView(ChartViewBase chartView, ChartAnimator animator);
	}

	// @protocol IShapeRenderer
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts14IShapeRenderer_")]
	interface IShapeRenderer
	{
		// @required -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Abstract]
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void DataSet(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface ChevronDownShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts24ChevronDownShapeRenderer")]
	interface ChevronDownShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface ChevronUpShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts22ChevronUpShapeRenderer")]
	interface ChevronUpShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface CircleShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts19CircleShapeRenderer")]
	interface CircleShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface CombinedChartData : BarLineScatterCandleBubbleChartData
	[BaseType(typeof(BarLineScatterCandleBubbleChartData), Name = "_TtC6Charts17CombinedChartData")]
	interface CombinedChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// @property (nonatomic, strong) LineChartData * _Null_unspecified lineData;
		[Export("lineData", ArgumentSemantic.Strong)]
		LineChartData LineData { get; set; }

		// @property (nonatomic, strong) BarChartData * _Null_unspecified barData;
		[Export("barData", ArgumentSemantic.Strong)]
		BarChartData BarData { get; set; }

		// @property (nonatomic, strong) ScatterChartData * _Null_unspecified scatterData;
		[Export("scatterData", ArgumentSemantic.Strong)]
		ScatterChartData ScatterData { get; set; }

		// @property (nonatomic, strong) CandleChartData * _Null_unspecified candleData;
		[Export("candleData", ArgumentSemantic.Strong)]
		CandleChartData CandleData { get; set; }

		// @property (nonatomic, strong) BubbleChartData * _Null_unspecified bubbleData;
		[Export("bubbleData", ArgumentSemantic.Strong)]
		BubbleChartData BubbleData { get; set; }

		// -(void)calcMinMax;
		[Export("calcMinMax")]
		void CalcMinMax();

		// @property (readonly, copy, nonatomic) NSArray<ChartData *> * _Nonnull allData;
		[Export("allData", ArgumentSemantic.Copy)]
		ChartData[] AllData { get; }

		// -(ChartData * _Nonnull)dataByIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("dataByIndex:")]
		ChartData DataByIndex(nint index);

		// -(BOOL)removeDataSet:(id<IChartDataSet> _Nonnull)dataSet __attribute__((warn_unused_result));
		[Export("removeDataSet:")]
		bool RemoveDataSet(IChartDataSet dataSet);

		// -(BOOL)removeDataSetByIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("removeDataSetByIndex:")]
		bool RemoveDataSetByIndex(nint index);

		// -(BOOL)removeEntry:(ChartDataEntry * _Nonnull)entry dataSetIndex:(NSInteger)dataSetIndex __attribute__((warn_unused_result));
		[Export("removeEntry:dataSetIndex:")]
		bool RemoveEntry(ChartDataEntry entry, nint dataSetIndex);

		// -(BOOL)removeEntryWithXValue:(double)xValue dataSetIndex:(NSInteger)dataSetIndex __attribute__((warn_unused_result));
		[Export("removeEntryWithXValue:dataSetIndex:")]
		bool RemoveEntryWithXValue(double xValue, nint dataSetIndex);

		// -(void)notifyDataChanged;
		[Export("notifyDataChanged")]
		void NotifyDataChanged();

		// -(ChartDataEntry * _Nullable)entryForHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("entryForHighlight:")]
		[return: NullAllowed]
		ChartDataEntry EntryForHighlight(ChartHighlight highlight);

		// -(id<IChartDataSet> _Null_unspecified)getDataSetByHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("getDataSetByHighlight:")]
		IChartDataSet GetDataSetByHighlight(ChartHighlight highlight);
	}

	// @protocol ScatterChartDataProvider <BarLineScatterCandleBubbleChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts24ScatterChartDataProvider_")]
	interface ScatterChartDataProvider : BarLineScatterCandleBubbleChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) ScatterChartData * _Nullable scatterData;
		[Abstract]
		[NullAllowed, Export("scatterData", ArgumentSemantic.Strong)]
		ScatterChartData ScatterData { get; }
	}

	// @protocol LineChartDataProvider <BarLineScatterCandleBubbleChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts21LineChartDataProvider_")]
	interface LineChartDataProvider : BarLineScatterCandleBubbleChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) LineChartData * _Nullable lineData;
		[Abstract]
		[NullAllowed, Export("lineData", ArgumentSemantic.Strong)]
		LineChartData LineData { get; }

		// @required -(ChartYAxis * _Nonnull)getAxis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Abstract]
		[Export("getAxis:")]
		ChartYAxis GetAxis(AxisDependency axis);
	}

	// @protocol CombinedChartDataProvider <BarChartDataProvider, BubbleChartDataProvider, CandleChartDataProvider, LineChartDataProvider, ScatterChartDataProvider>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts25CombinedChartDataProvider_")]
	interface CombinedChartDataProvider : BarChartDataProvider, BubbleChartDataProvider, CandleChartDataProvider, LineChartDataProvider, ScatterChartDataProvider
	{
		// @required @property (readonly, nonatomic, strong) CombinedChartData * _Nullable combinedData;
		[Abstract]
		[NullAllowed, Export("combinedData", ArgumentSemantic.Strong)]
		CombinedChartData CombinedData { get; }
	}

	// @interface CombinedChartRenderer : ChartDataRendererBase
	[BaseType(typeof(ChartDataRendererBase), Name = "_TtC6Charts21CombinedChartRenderer")]
	interface CombinedChartRenderer
	{
		// @property (nonatomic, weak) CombinedChartView * _Nullable chart;
		[NullAllowed, Export("chart", ArgumentSemantic.Weak)]
		CombinedChartView Chart { get; set; }

		// @property (nonatomic) BOOL drawValueAboveBarEnabled;
		[Export("drawValueAboveBarEnabled")]
		bool DrawValueAboveBarEnabled { get; set; }

		// @property (nonatomic) BOOL drawBarShadowEnabled;
		[Export("drawBarShadowEnabled")]
		bool DrawBarShadowEnabled { get; set; }

		// -(instancetype _Nonnull)initWithChart:(CombinedChartView * _Nonnull)chart animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithChart:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(CombinedChartView chart, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)initBuffers __attribute__((objc_method_family("none")));
		[Export("initBuffers")]
		void InitBuffers();

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);

		// -(ChartDataRendererBase * _Nullable)getSubRendererWithIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("getSubRendererWithIndex:")]
		[return: NullAllowed]
		ChartDataRendererBase GetSubRendererWithIndex(nint index);

		// @property (copy, nonatomic) NSArray<ChartDataRendererBase *> * _Nonnull subRenderers;
		[Export("subRenderers", ArgumentSemantic.Copy)]
		ChartDataRendererBase[] SubRenderers { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawValueAboveBarEnabled;
		[Export("isDrawValueAboveBarEnabled")]
		bool IsDrawValueAboveBarEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawBarShadowEnabled;
		[Export("isDrawBarShadowEnabled")]
		bool IsDrawBarShadowEnabled { get; }
	}

	// @interface CombinedChartView : BarLineChartViewBase <CombinedChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts17CombinedChartView")]
	interface CombinedChartView : CombinedChartDataProvider
	{
		// @property (nonatomic, strong) ChartData * _Nullable data;
		[NullAllowed, Export("data", ArgumentSemantic.Strong)]
		ChartData Data { get; set; }

		// @property (nonatomic, strong) id<IChartFillFormatter> _Nonnull fillFormatter;
		[Export("fillFormatter", ArgumentSemantic.Strong)]
		IChartFillFormatter FillFormatter { get; set; }

		// -(ChartHighlight * _Nullable)getHighlightByTouchPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getHighlightByTouchPoint:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightByTouchPoint(CGPoint pt);

		// @property (readonly, nonatomic, strong) CombinedChartData * _Nullable combinedData;
		[NullAllowed, Export("combinedData", ArgumentSemantic.Strong)]
		CombinedChartData CombinedData { get; }

		// @property (readonly, nonatomic, strong) LineChartData * _Nullable lineData;
		[NullAllowed, Export("lineData", ArgumentSemantic.Strong)]
		LineChartData LineData { get; }

		// @property (readonly, nonatomic, strong) BarChartData * _Nullable barData;
		[NullAllowed, Export("barData", ArgumentSemantic.Strong)]
		BarChartData BarData { get; }

		// @property (readonly, nonatomic, strong) ScatterChartData * _Nullable scatterData;
		[NullAllowed, Export("scatterData", ArgumentSemantic.Strong)]
		ScatterChartData ScatterData { get; }

		// @property (readonly, nonatomic, strong) CandleChartData * _Nullable candleData;
		[NullAllowed, Export("candleData", ArgumentSemantic.Strong)]
		CandleChartData CandleData { get; }

		// @property (readonly, nonatomic, strong) BubbleChartData * _Nullable bubbleData;
		[NullAllowed, Export("bubbleData", ArgumentSemantic.Strong)]
		BubbleChartData BubbleData { get; }

		// @property (nonatomic) BOOL drawValueAboveBarEnabled;
		[Export("drawValueAboveBarEnabled")]
		bool DrawValueAboveBarEnabled { get; set; }

		// @property (nonatomic) BOOL drawBarShadowEnabled;
		[Export("drawBarShadowEnabled")]
		bool DrawBarShadowEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawValueAboveBarEnabled;
		[Export("isDrawValueAboveBarEnabled")]
		bool IsDrawValueAboveBarEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawBarShadowEnabled;
		[Export("isDrawBarShadowEnabled")]
		bool IsDrawBarShadowEnabled { get; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull drawOrder;
		[Export("drawOrder", ArgumentSemantic.Copy)]
		NSNumber[] DrawOrder { get; set; }

		// @property (nonatomic) BOOL highlightFullBarEnabled;
		[Export("highlightFullBarEnabled")]
		bool HighlightFullBarEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isHighlightFullBarEnabled;
		[Export("isHighlightFullBarEnabled")]
		bool IsHighlightFullBarEnabled { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface CombinedChartHighlighter : ChartHighlighter
	[BaseType(typeof(ChartHighlighter))]
	interface CombinedChartHighlighter
	{
		// -(instancetype _Nonnull)initWithChart:(id<CombinedChartDataProvider> _Nonnull)chart barDataProvider:(id<BarChartDataProvider> _Nonnull)barDataProvider __attribute__((objc_designated_initializer));
		[Export("initWithChart:barDataProvider:")]
		[DesignatedInitializer]
		IntPtr Constructor(CombinedChartDataProvider chart, BarChartDataProvider barDataProvider);

		// -(NSArray<ChartHighlight *> * _Nonnull)getHighlightsWithXValue:(double)xValue x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightsWithXValue:x:y:")]
		ChartHighlight[] GetHighlightsWithXValue(double xValue, nfloat x, nfloat y);
	}

	// @interface CrossShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts18CrossShapeRenderer")]
	interface CrossShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface ChartDataApproximator : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartDataApproximator
	{
		// +(NSArray<NSValue *> * _Nonnull)reduceWithDouglasPeuker:(NSArray<NSValue *> * _Nonnull)points tolerance:(CGFloat)tolerance __attribute__((warn_unused_result));
		[Static]
		[Export("reduceWithDouglasPeuker:tolerance:")]
		NSValue[] ReduceWithDouglasPeuker(NSValue[] points, nfloat tolerance);
	}

	// @interface Charts_Swift_2883 (ChartDataApproximator)
	[Category]
	[BaseType(typeof(ChartDataApproximator))]
	interface ChartDataApproximator_Charts_Swift_2883
	{
		// +(NSArray<NSValue *> * _Nonnull)reduceWithDouglasPeukerN:(NSArray<NSValue *> * _Nonnull)points resultCount:(NSInteger)resultCount __attribute__((warn_unused_result));
		[Static]
		[Export("reduceWithDouglasPeukerN:resultCount:")]
		NSValue[] ReduceWithDouglasPeukerN(NSValue[] points, nint resultCount);
	}

	// @protocol IChartAxisValueFormatter
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface IChartAxisValueFormatter
	{
		// @required -(NSString * _Nonnull)stringForValue:(double)value axis:(ChartAxisBase * _Nullable)axis __attribute__((warn_unused_result));
		[Abstract]
		[Export("stringForValue:axis:")]
		string Axis(double value, [NullAllowed] ChartAxisBase axis);
	}

	// @interface ChartDefaultAxisValueFormatter : NSObject <IChartAxisValueFormatter>
	[BaseType(typeof(NSObject))]
	interface ChartDefaultAxisValueFormatter : IChartAxisValueFormatter
	{
		// @property (copy, nonatomic) NSString * _Nonnull (^ _Nullable)(double, ChartAxisBase * _Nullable) block;
		[NullAllowed, Export("block", ArgumentSemantic.Copy)]
		Func<double, ChartAxisBase, NSString> Block { get; set; }

		// @property (nonatomic) BOOL hasAutoDecimals;
		[Export("hasAutoDecimals")]
		bool HasAutoDecimals { get; set; }

		// @property (nonatomic, strong) NSNumberFormatter * _Nullable formatter;
		[NullAllowed, Export("formatter", ArgumentSemantic.Strong)]
		NSNumberFormatter Formatter { get; set; }

		// -(instancetype _Nonnull)initWithFormatter:(NSNumberFormatter * _Nonnull)formatter __attribute__((objc_designated_initializer));
		[Export("initWithFormatter:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSNumberFormatter formatter);

		// -(instancetype _Nonnull)initWithDecimals:(NSInteger)decimals __attribute__((objc_designated_initializer));
		[Export("initWithDecimals:")]
		[DesignatedInitializer]
		IntPtr Constructor(nint decimals);

		// -(instancetype _Nonnull)initWithBlock:(NSString * _Nonnull (^ _Nonnull)(double, ChartAxisBase * _Nullable))block __attribute__((objc_designated_initializer));
		[Export("initWithBlock:")]
		[DesignatedInitializer]
		IntPtr Constructor(Func<double, ChartAxisBase, NSString> block);

		// +(ChartDefaultAxisValueFormatter * _Nullable)withBlock:(NSString * _Nonnull (^ _Nonnull)(double, ChartAxisBase * _Nullable))block __attribute__((warn_unused_result));
		[Static]
		[Export("withBlock:")]
		[return: NullAllowed]
		ChartDefaultAxisValueFormatter WithBlock(Func<double, ChartAxisBase, NSString> block);

		// -(NSString * _Nonnull)stringForValue:(double)value axis:(ChartAxisBase * _Nullable)axis __attribute__((warn_unused_result));
		[Export("stringForValue:axis:")]
		string StringForValue(double value, [NullAllowed] ChartAxisBase axis);
	}

	// @protocol IChartFillFormatter
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface IChartFillFormatter
	{
		// @required -(CGFloat)getFillLinePositionWithDataSet:(id<ILineChartDataSet> _Nonnull)dataSet dataProvider:(id<LineChartDataProvider> _Nonnull)dataProvider __attribute__((warn_unused_result));
		[Abstract]
		[Export("getFillLinePositionWithDataSet:dataProvider:")]
		nfloat DataProvider(ILineChartDataSet dataSet, LineChartDataProvider dataProvider);
	}

	// @interface ChartDefaultFillFormatter : NSObject <IChartFillFormatter>
	[BaseType(typeof(NSObject))]
	interface ChartDefaultFillFormatter : IChartFillFormatter
	{
		// @property (copy, nonatomic) CGFloat (^ _Nullable)(id<ILineChartDataSet> _Nonnull, id<LineChartDataProvider> _Nonnull) block;
		[NullAllowed, Export("block", ArgumentSemantic.Copy)]
		Func<ILineChartDataSet, LineChartDataProvider, nfloat> Block { get; set; }

		// -(instancetype _Nonnull)initWithBlock:(CGFloat (^ _Nonnull)(id<ILineChartDataSet> _Nonnull, id<LineChartDataProvider> _Nonnull))block __attribute__((objc_designated_initializer));
		[Export("initWithBlock:")]
		[DesignatedInitializer]
		IntPtr Constructor(Func<ILineChartDataSet, LineChartDataProvider, nfloat> block);

		// +(ChartDefaultFillFormatter * _Nullable)withBlock:(CGFloat (^ _Nonnull)(id<ILineChartDataSet> _Nonnull, id<LineChartDataProvider> _Nonnull))block __attribute__((warn_unused_result));
		[Static]
		[Export("withBlock:")]
		[return: NullAllowed]
		ChartDefaultFillFormatter WithBlock(Func<ILineChartDataSet, LineChartDataProvider, nfloat> block);

		// -(CGFloat)getFillLinePositionWithDataSet:(id<ILineChartDataSet> _Nonnull)dataSet dataProvider:(id<LineChartDataProvider> _Nonnull)dataProvider __attribute__((warn_unused_result));
		[Export("getFillLinePositionWithDataSet:dataProvider:")]
		nfloat GetFillLinePositionWithDataSet(ILineChartDataSet dataSet, LineChartDataProvider dataProvider);
	}

	// @protocol IChartValueFormatter
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface IChartValueFormatter
	{
		// @required -(NSString * _Nonnull)stringForValue:(double)value entry:(ChartDataEntry * _Nonnull)entry dataSetIndex:(NSInteger)dataSetIndex viewPortHandler:(ChartViewPortHandler * _Nullable)viewPortHandler __attribute__((warn_unused_result));
		[Abstract]
		[Export("stringForValue:entry:dataSetIndex:viewPortHandler:")]
		string Entry(double value, ChartDataEntry entry, nint dataSetIndex, [NullAllowed] ChartViewPortHandler viewPortHandler);
	}

	// @interface ChartDefaultValueFormatter : NSObject <IChartValueFormatter>
	[BaseType(typeof(NSObject))]
	interface ChartDefaultValueFormatter : IChartValueFormatter
	{
		// @property (copy, nonatomic) NSString * _Nonnull (^ _Nullable)(double, ChartDataEntry * _Nonnull, NSInteger, ChartViewPortHandler * _Nullable) block;
		[NullAllowed, Export("block", ArgumentSemantic.Copy)]
		Func<double, ChartDataEntry, nint, ChartViewPortHandler, NSString> Block { get; set; }

		// @property (nonatomic) BOOL hasAutoDecimals;
		[Export("hasAutoDecimals")]
		bool HasAutoDecimals { get; set; }

		// @property (nonatomic, strong) NSNumberFormatter * _Nullable formatter;
		[NullAllowed, Export("formatter", ArgumentSemantic.Strong)]
		NSNumberFormatter Formatter { get; set; }

		// -(instancetype _Nonnull)initWithFormatter:(NSNumberFormatter * _Nonnull)formatter __attribute__((objc_designated_initializer));
		[Export("initWithFormatter:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSNumberFormatter formatter);

		// -(instancetype _Nonnull)initWithDecimals:(NSInteger)decimals __attribute__((objc_designated_initializer));
		[Export("initWithDecimals:")]
		[DesignatedInitializer]
		IntPtr Constructor(nint decimals);

		// -(instancetype _Nonnull)initWithBlock:(NSString * _Nonnull (^ _Nonnull)(double, ChartDataEntry * _Nonnull, NSInteger, ChartViewPortHandler * _Nullable))block __attribute__((objc_designated_initializer));
		[Export("initWithBlock:")]
		[DesignatedInitializer]
		IntPtr Constructor(Func<double, ChartDataEntry, nint, ChartViewPortHandler, NSString> block);

		// +(ChartDefaultValueFormatter * _Nullable)withBlock:(NSString * _Nonnull (^ _Nonnull)(double, ChartDataEntry * _Nonnull, NSInteger, ChartViewPortHandler * _Nullable))block __attribute__((warn_unused_result));
		[Static]
		[Export("withBlock:")]
		[return: NullAllowed]
		ChartDefaultValueFormatter WithBlock(Func<double, ChartDataEntry, nint, ChartViewPortHandler, NSString> block);

		// -(NSString * _Nonnull)stringForValue:(double)value entry:(ChartDataEntry * _Nonnull)entry dataSetIndex:(NSInteger)dataSetIndex viewPortHandler:(ChartViewPortHandler * _Nullable)viewPortHandler __attribute__((warn_unused_result));
		[Export("stringForValue:entry:dataSetIndex:viewPortHandler:")]
		string StringForValue(double value, ChartDataEntry entry, nint dataSetIndex, [NullAllowed] ChartViewPortHandler viewPortHandler);
	}

	// @interface ChartDescription : ChartComponentBase
	[BaseType(typeof(ChartComponentBase))]
	interface ChartDescription
	{
		// @property (copy, nonatomic) NSString * _Nullable text;
		[NullAllowed, Export("text")]
		string Text { get; set; }

		// @property (nonatomic) NSTextAlignment textAlign;
		//[Export ("textAlign", ArgumentSemantic.Assign)]
		//NSTextAlignment TextAlign { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }
	}

	// @interface ChartFill : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartFill
	{
		// @property (readonly, nonatomic) enum ChartFillType type;
		[Export("type")]
		ChartFillType Type { get; }

		// @property (readonly, nonatomic) CGColorRef _Nullable color;
		[NullAllowed, Export("color")]
		unsafe CGColor Color { get; }

		// @property (readonly, nonatomic) CGGradientRef _Nullable gradient;
		[NullAllowed, Export("gradient")]
		unsafe CGGradient Gradient { get; }

		// @property (readonly, nonatomic) CGFloat gradientAngle;
		[Export("gradientAngle")]
		nfloat GradientAngle { get; }

		// @property (readonly, nonatomic) CGPoint gradientStartOffsetPercent;
		[Export("gradientStartOffsetPercent")]
		CGPoint GradientStartOffsetPercent { get; }

		// @property (readonly, nonatomic) CGFloat gradientStartRadiusPercent;
		[Export("gradientStartRadiusPercent")]
		nfloat GradientStartRadiusPercent { get; }

		// @property (readonly, nonatomic) CGPoint gradientEndOffsetPercent;
		[Export("gradientEndOffsetPercent")]
		CGPoint GradientEndOffsetPercent { get; }

		// @property (readonly, nonatomic) CGFloat gradientEndRadiusPercent;
		[Export("gradientEndRadiusPercent")]
		nfloat GradientEndRadiusPercent { get; }

		// @property (readonly, nonatomic) CGImageRef _Nullable image;
		[NullAllowed, Export("image")]
		unsafe CGImage Image { get; }

		// @property (readonly, nonatomic) CGLayerRef _Nullable layer;
		[NullAllowed, Export("layer")]
		unsafe CGLayer Layer { get; }

		// -(instancetype _Nonnull)initWithCGColor:(CGColorRef _Nonnull)CGColor __attribute__((objc_designated_initializer));
		[Export("initWithCGColor:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor(CGColor CGColor);

		// -(instancetype _Nonnull)initWithColor:(UIColor * _Nonnull)color;
		[Export("initWithColor:")]
		IntPtr Constructor(UIColor color);

		// -(instancetype _Nonnull)initWithLinearGradient:(CGGradientRef _Nonnull)linearGradient angle:(CGFloat)angle __attribute__((objc_designated_initializer));
		[Export("initWithLinearGradient:angle:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor(CGGradient linearGradient, nfloat angle);

		// -(instancetype _Nonnull)initWithRadialGradient:(CGGradientRef _Nonnull)radialGradient startOffsetPercent:(CGPoint)startOffsetPercent startRadiusPercent:(CGFloat)startRadiusPercent endOffsetPercent:(CGPoint)endOffsetPercent endRadiusPercent:(CGFloat)endRadiusPercent __attribute__((objc_designated_initializer));
		[Export("initWithRadialGradient:startOffsetPercent:startRadiusPercent:endOffsetPercent:endRadiusPercent:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor(CGGradient radialGradient, CGPoint startOffsetPercent, nfloat startRadiusPercent, CGPoint endOffsetPercent, nfloat endRadiusPercent);

		// -(instancetype _Nonnull)initWithRadialGradient:(CGGradientRef _Nonnull)radialGradient;
		[Export("initWithRadialGradient:")]
		unsafe IntPtr Constructor(CGGradient radialGradient);

		// -(instancetype _Nonnull)initWithCGImage:(CGImageRef _Nonnull)CGImage tiled:(BOOL)tiled __attribute__((objc_designated_initializer));
		[Export("initWithCGImage:tiled:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor(CGImage CGImage, bool tiled);

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image tiled:(BOOL)tiled;
		[Export("initWithImage:tiled:")]
		IntPtr Constructor(UIImage image, bool tiled);

		// -(instancetype _Nonnull)initWithCGImage:(CGImageRef _Nonnull)CGImage;
		[Export("initWithCGImage:")]
		unsafe IntPtr Constructor(CGImage CGImage);

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image;
		[Export("initWithImage:")]
		IntPtr Constructor(UIImage image);

		// -(instancetype _Nonnull)initWithCGLayer:(CGLayerRef _Nonnull)CGLayer __attribute__((objc_designated_initializer));
		[Export("initWithCGLayer:")]
		[DesignatedInitializer]
		unsafe IntPtr Constructor(CGLayer CGLayer);

		// +(ChartFill * _Nonnull)fillWithCGColor:(CGColorRef _Nonnull)CGColor __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithCGColor:")]
		unsafe ChartFill FillWithCGColor(CGColor CGColor);

		// +(ChartFill * _Nonnull)fillWithColor:(UIColor * _Nonnull)color __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithColor:")]
		ChartFill FillWithColor(UIColor color);

		// +(ChartFill * _Nonnull)fillWithLinearGradient:(CGGradientRef _Nonnull)linearGradient angle:(CGFloat)angle __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithLinearGradient:angle:")]
		unsafe ChartFill FillWithLinearGradient(CGGradient linearGradient, nfloat angle);

		// +(ChartFill * _Nonnull)fillWithRadialGradient:(CGGradientRef _Nonnull)radialGradient startOffsetPercent:(CGPoint)startOffsetPercent startRadiusPercent:(CGFloat)startRadiusPercent endOffsetPercent:(CGPoint)endOffsetPercent endRadiusPercent:(CGFloat)endRadiusPercent __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithRadialGradient:startOffsetPercent:startRadiusPercent:endOffsetPercent:endRadiusPercent:")]
		unsafe ChartFill FillWithRadialGradient(CGGradient radialGradient, CGPoint startOffsetPercent, nfloat startRadiusPercent, CGPoint endOffsetPercent, nfloat endRadiusPercent);

		// +(ChartFill * _Nonnull)fillWithRadialGradient:(CGGradientRef _Nonnull)radialGradient __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithRadialGradient:")]
		unsafe ChartFill FillWithRadialGradient(CGGradient radialGradient);

		// +(ChartFill * _Nonnull)fillWithCGImage:(CGImageRef _Nonnull)CGImage tiled:(BOOL)tiled __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithCGImage:tiled:")]
		unsafe ChartFill FillWithCGImage(CGImage CGImage, bool tiled);

		// +(ChartFill * _Nonnull)fillWithImage:(UIImage * _Nonnull)image tiled:(BOOL)tiled __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithImage:tiled:")]
		ChartFill FillWithImage(UIImage image, bool tiled);

		// +(ChartFill * _Nonnull)fillWithCGImage:(CGImageRef _Nonnull)CGImage __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithCGImage:")]
		unsafe ChartFill FillWithCGImage(CGImage CGImage);

		// +(ChartFill * _Nonnull)fillWithImage:(UIImage * _Nonnull)image __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithImage:")]
		ChartFill FillWithImage(UIImage image);

		// +(ChartFill * _Nonnull)fillWithCGLayer:(CGLayerRef _Nonnull)CGLayer __attribute__((warn_unused_result));
		[Static]
		[Export("fillWithCGLayer:")]
		unsafe ChartFill FillWithCGLayer(CGLayer CGLayer);

		// -(void)fillPathWithContext:(CGContextRef _Nonnull)context rect:(CGRect)rect;
		[Export("fillPathWithContext:rect:")]
		unsafe void FillPathWithContext(CGContext context, CGRect rect);
	}

	// @interface ChartHighlight : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartHighlight
	{
		// @property (nonatomic) NSInteger dataIndex;
		[Export("dataIndex")]
		nint DataIndex { get; set; }

		// @property (nonatomic) CGFloat drawX;
		[Export("drawX")]
		nfloat DrawX { get; set; }

		// @property (nonatomic) CGFloat drawY;
		[Export("drawY")]
		nfloat DrawY { get; set; }

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y xPx:(CGFloat)xPx yPx:(CGFloat)yPx dataIndex:(NSInteger)dataIndex dataSetIndex:(NSInteger)dataSetIndex stackIndex:(NSInteger)stackIndex axis:(enum AxisDependency)axis __attribute__((objc_designated_initializer));
		[Export("initWithX:y:xPx:yPx:dataIndex:dataSetIndex:stackIndex:axis:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y, nfloat xPx, nfloat yPx, nint dataIndex, nint dataSetIndex, nint stackIndex, AxisDependency axis);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y xPx:(CGFloat)xPx yPx:(CGFloat)yPx dataSetIndex:(NSInteger)dataSetIndex stackIndex:(NSInteger)stackIndex axis:(enum AxisDependency)axis;
		[Export("initWithX:y:xPx:yPx:dataSetIndex:stackIndex:axis:")]
		IntPtr Constructor(double x, double y, nfloat xPx, nfloat yPx, nint dataSetIndex, nint stackIndex, AxisDependency axis);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y xPx:(CGFloat)xPx yPx:(CGFloat)yPx dataSetIndex:(NSInteger)dataSetIndex axis:(enum AxisDependency)axis __attribute__((objc_designated_initializer));
		[Export("initWithX:y:xPx:yPx:dataSetIndex:axis:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y, nfloat xPx, nfloat yPx, nint dataSetIndex, AxisDependency axis);

		// -(instancetype _Nonnull)initWithX:(double)x y:(double)y dataSetIndex:(NSInteger)dataSetIndex dataIndex:(NSInteger)dataIndex __attribute__((objc_designated_initializer));
		[Export("initWithX:y:dataSetIndex:dataIndex:")]
		[DesignatedInitializer]
		IntPtr Constructor(double x, double y, nint dataSetIndex, nint dataIndex);

		// -(instancetype _Nonnull)initWithX:(double)x dataSetIndex:(NSInteger)dataSetIndex stackIndex:(NSInteger)stackIndex;
		[Export("initWithX:dataSetIndex:stackIndex:")]
		IntPtr Constructor(double x, nint dataSetIndex, nint stackIndex);

		// @property (readonly, nonatomic) double x;
		[Export("x")]
		double X { get; }

		// @property (readonly, nonatomic) double y;
		[Export("y")]
		double Y { get; }

		// @property (readonly, nonatomic) CGFloat xPx;
		[Export("xPx")]
		nfloat XPx { get; }

		// @property (readonly, nonatomic) CGFloat yPx;
		[Export("yPx")]
		nfloat YPx { get; }

		// @property (readonly, nonatomic) NSInteger dataSetIndex;
		[Export("dataSetIndex")]
		nint DataSetIndex { get; }

		// @property (readonly, nonatomic) NSInteger stackIndex;
		[Export("stackIndex")]
		nint StackIndex { get; }

		// @property (readonly, nonatomic) enum AxisDependency axis;
		[Export("axis")]
		AxisDependency Axis { get; }

		// @property (readonly, nonatomic) BOOL isStacked;
		[Export("isStacked")]
		bool IsStacked { get; }

		// -(void)setDrawWithX:(CGFloat)x y:(CGFloat)y;
		[Export("setDrawWithX:y:")]
		void SetDrawWithX(nfloat x, nfloat y);

		// -(void)setDrawWithPt:(CGPoint)pt;
		[Export("setDrawWithPt:")]
		void SetDrawWithPt(CGPoint pt);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export("description")]
		string Description { get; }
	}

	// @interface Charts_Swift_3131 (ChartHighlight)
	[Category]
	[BaseType(typeof(ChartHighlight))]
	interface ChartHighlight_Charts_Swift_3131
	{
		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
		[Export("isEqual:")]
		bool IsEqual([NullAllowed] NSObject @object);
	}

	// @interface HorizontalBarChartRenderer : BarChartRenderer
	[BaseType(typeof(BarChartRenderer), Name = "_TtC6Charts26HorizontalBarChartRenderer")]
	interface HorizontalBarChartRenderer
	{
		// -(instancetype _Nonnull)initWithDataProvider:(id<BarChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(BarChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)initBuffers __attribute__((objc_method_family("none")));
		[Export("initBuffers")]
		void InitBuffers();

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<IBarChartDataSet> _Nonnull)dataSet index:(NSInteger)index;
		[Export("drawDataSetWithContext:dataSet:index:")]
		unsafe void DrawDataSetWithContext(CGContext context, IBarChartDataSet dataSet, nint index);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(BOOL)isDrawingValuesAllowedWithDataProvider:(id<ChartDataProvider> _Nullable)dataProvider __attribute__((warn_unused_result));
		[Export("isDrawingValuesAllowedWithDataProvider:")]
		bool IsDrawingValuesAllowedWithDataProvider([NullAllowed] ChartDataProvider dataProvider);
	}

	// @interface HorizontalBarChartView : BarChartView
	[BaseType(typeof(BarChartView), Name = "_TtC6Charts22HorizontalBarChartView")]
	interface HorizontalBarChartView
	{
		// -(CGPoint)getMarkerPositionWithHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("getMarkerPositionWithHighlight:")]
		CGPoint GetMarkerPositionWithHighlight(ChartHighlight highlight);

		// -(CGRect)getBarBoundsWithEntry:(BarChartDataEntry * _Nonnull)e __attribute__((warn_unused_result));
		[Export("getBarBoundsWithEntry:")]
		CGRect GetBarBoundsWithEntry(BarChartDataEntry e);

		// -(CGPoint)getPositionWithEntry:(ChartDataEntry * _Nonnull)e axis:(enum AxisDependency)axis __attribute__((warn_unused_result));
		[Export("getPositionWithEntry:axis:")]
		CGPoint GetPositionWithEntry(ChartDataEntry e, AxisDependency axis);

		// -(ChartHighlight * _Nullable)getHighlightByTouchPoint:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("getHighlightByTouchPoint:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightByTouchPoint(CGPoint pt);

		// @property (readonly, nonatomic) double lowestVisibleX;
		[Export("lowestVisibleX")]
		double LowestVisibleX { get; }

		// @property (readonly, nonatomic) double highestVisibleX;
		[Export("highestVisibleX")]
		double HighestVisibleX { get; }

		// -(void)setVisibleXRangeMaximum:(double)maxXRange;
		[Export("setVisibleXRangeMaximum:")]
		void SetVisibleXRangeMaximum(double maxXRange);

		// -(void)setVisibleXRangeMinimum:(double)minXRange;
		[Export("setVisibleXRangeMinimum:")]
		void SetVisibleXRangeMinimum(double minXRange);

		// -(void)setVisibleXRangeWithMinXRange:(double)minXRange maxXRange:(double)maxXRange;
		[Export("setVisibleXRangeWithMinXRange:maxXRange:")]
		void SetVisibleXRangeWithMinXRange(double minXRange, double maxXRange);

		// -(void)setVisibleYRangeMaximum:(double)maxYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeMaximum:axis:")]
		void SetVisibleYRangeMaximum(double maxYRange, AxisDependency axis);

		// -(void)setVisibleYRangeMinimum:(double)minYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeMinimum:axis:")]
		void SetVisibleYRangeMinimum(double minYRange, AxisDependency axis);

		// -(void)setVisibleYRangeWithMinYRange:(double)minYRange maxYRange:(double)maxYRange axis:(enum AxisDependency)axis;
		[Export("setVisibleYRangeWithMinYRange:maxYRange:axis:")]
		void SetVisibleYRangeWithMinYRange(double minYRange, double maxYRange, AxisDependency axis);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface HorizontalBarChartHighlighter : BarChartHighlighter
	[BaseType(typeof(BarChartHighlighter))]
	interface HorizontalBarChartHighlighter
	{
		// -(ChartHighlight * _Nullable)getHighlightWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightWithX:y:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightWithX(nfloat x, nfloat y);

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);
	}

	// @protocol ILineRadarChartDataSet <ILineScatterCandleRadarChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts22ILineRadarChartDataSet_")]
	interface ILineRadarChartDataSet : ILineScatterCandleRadarChartDataSet
	{
		// @required @property (nonatomic, strong) UIColor * _Nonnull fillColor;
		[Abstract]
		[Export("fillColor", ArgumentSemantic.Strong)]
		UIColor FillColor { get; set; }

		// @required @property (nonatomic, strong) ChartFill * _Nullable fill;
		[Abstract]
		[NullAllowed, Export("fill", ArgumentSemantic.Strong)]
		ChartFill Fill { get; set; }

		// @required @property (nonatomic) CGFloat fillAlpha;
		[Abstract]
		[Export("fillAlpha")]
		nfloat FillAlpha { get; set; }

		// @required @property (nonatomic) CGFloat lineWidth;
		[Abstract]
		[Export("lineWidth")]
		nfloat LineWidth { get; set; }

		// @required @property (nonatomic) BOOL drawFilledEnabled;
		[Abstract]
		[Export("drawFilledEnabled")]
		bool DrawFilledEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawFilledEnabled;
		[Abstract]
		[Export("isDrawFilledEnabled")]
		bool IsDrawFilledEnabled { get; }
	}

	// @protocol ILineChartDataSet <ILineRadarChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts17ILineChartDataSet_")]
	interface ILineChartDataSet : ILineRadarChartDataSet
	{
		// @required @property (nonatomic) enum LineChartMode mode;
		[Abstract]
		[Export("mode", ArgumentSemantic.Assign)]
		LineChartMode Mode { get; set; }

		// @required @property (nonatomic) CGFloat cubicIntensity;
		[Abstract]
		[Export("cubicIntensity")]
		nfloat CubicIntensity { get; set; }

		// @required @property (nonatomic) CGFloat circleRadius;
		[Abstract]
		[Export("circleRadius")]
		nfloat CircleRadius { get; set; }

		// @required @property (nonatomic) CGFloat circleHoleRadius;
		[Abstract]
		[Export("circleHoleRadius")]
		nfloat CircleHoleRadius { get; set; }

		// @required @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull circleColors;
		[Abstract]
		[Export("circleColors", ArgumentSemantic.Copy)]
		UIColor[] CircleColors { get; set; }

		// @required -(UIColor * _Nullable)getCircleColorAtIndex:(NSInteger)atIndex __attribute__((warn_unused_result));
		[Abstract]
		[Export("getCircleColorAtIndex:")]
		[return: NullAllowed]
		UIColor GetCircleColorAtIndex(nint atIndex);

		// @required -(void)setCircleColor:(UIColor * _Nonnull)color;
		[Abstract]
		[Export("setCircleColor:")]
		void SetCircleColor(UIColor color);

		// @required -(void)resetCircleColors:(NSInteger)index;
		[Abstract]
		[Export("resetCircleColors:")]
		void ResetCircleColors(nint index);

		// @required @property (nonatomic) BOOL drawCirclesEnabled;
		[Abstract]
		[Export("drawCirclesEnabled")]
		bool DrawCirclesEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawCirclesEnabled;
		[Abstract]
		[Export("isDrawCirclesEnabled")]
		bool IsDrawCirclesEnabled { get; }

		// @required @property (nonatomic, strong) UIColor * _Nullable circleHoleColor;
		[Abstract]
		[NullAllowed, Export("circleHoleColor", ArgumentSemantic.Strong)]
		UIColor CircleHoleColor { get; set; }

		// @required @property (nonatomic) BOOL drawCircleHoleEnabled;
		[Abstract]
		[Export("drawCircleHoleEnabled")]
		bool DrawCircleHoleEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawCircleHoleEnabled;
		[Abstract]
		[Export("isDrawCircleHoleEnabled")]
		bool IsDrawCircleHoleEnabled { get; }

		// @required @property (readonly, nonatomic) CGFloat lineDashPhase;
		[Abstract]
		[Export("lineDashPhase")]
		nfloat LineDashPhase { get; }

		// @required @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineDashLengths;
		[Abstract]
		[NullAllowed, Export("lineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] LineDashLengths { get; set; }

		// @required @property (nonatomic) CGLineCap lineCapType;
		[Abstract]
		[Export("lineCapType", ArgumentSemantic.Assign)]
		CGLineCap LineCapType { get; set; }

		// @required @property (nonatomic, strong) id<IChartFillFormatter> _Nullable fillFormatter;
		[Abstract]
		[NullAllowed, Export("fillFormatter", ArgumentSemantic.Strong)]
		IChartFillFormatter FillFormatter { get; set; }
	}

	// @protocol IChartMarker
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol]
	interface IChartMarker
	{
		// @required @property (readonly, nonatomic) CGPoint offset;
		[Abstract]
		[Export("offset")]
		CGPoint Offset { get; }

		// @required -(CGPoint)offsetForDrawingAtPoint:(CGPoint)atPoint __attribute__((warn_unused_result));
		[Abstract]
		[Export("offsetForDrawingAtPoint:")]
		CGPoint OffsetForDrawingAtPoint(CGPoint atPoint);

		// @required -(void)refreshContentWithEntry:(ChartDataEntry * _Nonnull)entry highlight:(ChartHighlight * _Nonnull)highlight;
		[Abstract]
		[Export("refreshContentWithEntry:highlight:")]
		void RefreshContentWithEntry(ChartDataEntry entry, ChartHighlight highlight);

		// @required -(void)drawWithContext:(CGContextRef _Nonnull)context point:(CGPoint)point;
		[Abstract]
		[Export("drawWithContext:point:")]
		unsafe void DrawWithContext(CGContext context, CGPoint point);
	}

	// @protocol IPieChartDataSet <IChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts16IPieChartDataSet_")]
	interface IPieChartDataSet : IChartDataSet
	{
		// @required @property (nonatomic) CGFloat sliceSpace;
		[Abstract]
		[Export("sliceSpace")]
		nfloat SliceSpace { get; set; }

		// @required @property (nonatomic) BOOL automaticallyDisableSliceSpacing;
		[Abstract]
		[Export("automaticallyDisableSliceSpacing")]
		bool AutomaticallyDisableSliceSpacing { get; set; }

		// @required @property (nonatomic) CGFloat selectionShift;
		[Abstract]
		[Export("selectionShift")]
		nfloat SelectionShift { get; set; }

		// @required @property (nonatomic) enum PieChartValuePosition xValuePosition;
		[Abstract]
		[Export("xValuePosition", ArgumentSemantic.Assign)]
		PieChartValuePosition XValuePosition { get; set; }

		// @required @property (nonatomic) enum PieChartValuePosition yValuePosition;
		[Abstract]
		[Export("yValuePosition", ArgumentSemantic.Assign)]
		PieChartValuePosition YValuePosition { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable valueLineColor;
		[Abstract]
		[NullAllowed, Export("valueLineColor", ArgumentSemantic.Strong)]
		UIColor ValueLineColor { get; set; }

		// @required @property (nonatomic) BOOL useValueColorForLine;
		[Abstract]
		[Export("useValueColorForLine")]
		bool UseValueColorForLine { get; set; }

		// @required @property (nonatomic) CGFloat valueLineWidth;
		[Abstract]
		[Export("valueLineWidth")]
		nfloat ValueLineWidth { get; set; }

		// @required @property (nonatomic) CGFloat valueLinePart1OffsetPercentage;
		[Abstract]
		[Export("valueLinePart1OffsetPercentage")]
		nfloat ValueLinePart1OffsetPercentage { get; set; }

		// @required @property (nonatomic) CGFloat valueLinePart1Length;
		[Abstract]
		[Export("valueLinePart1Length")]
		nfloat ValueLinePart1Length { get; set; }

		// @required @property (nonatomic) CGFloat valueLinePart2Length;
		[Abstract]
		[Export("valueLinePart2Length")]
		nfloat ValueLinePart2Length { get; set; }

		// @required @property (nonatomic) BOOL valueLineVariableLength;
		[Abstract]
		[Export("valueLineVariableLength")]
		bool ValueLineVariableLength { get; set; }

		// @required @property (nonatomic, strong) UIFont * _Nullable entryLabelFont;
		[Abstract]
		[NullAllowed, Export("entryLabelFont", ArgumentSemantic.Strong)]
		UIFont EntryLabelFont { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable entryLabelColor;
		[Abstract]
		[NullAllowed, Export("entryLabelColor", ArgumentSemantic.Strong)]
		UIColor EntryLabelColor { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable highlightColor;
		[Abstract]
		[NullAllowed, Export("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }
	}

	// @protocol IRadarChartDataSet <ILineRadarChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts18IRadarChartDataSet_")]
	interface IRadarChartDataSet : ILineRadarChartDataSet
	{
		// @required @property (nonatomic) BOOL drawHighlightCircleEnabled;
		[Abstract]
		[Export("drawHighlightCircleEnabled")]
		bool DrawHighlightCircleEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isDrawHighlightCircleEnabled;
		[Abstract]
		[Export("isDrawHighlightCircleEnabled")]
		bool IsDrawHighlightCircleEnabled { get; }

		// @required @property (nonatomic, strong) UIColor * _Nullable highlightCircleFillColor;
		[Abstract]
		[NullAllowed, Export("highlightCircleFillColor", ArgumentSemantic.Strong)]
		UIColor HighlightCircleFillColor { get; set; }

		// @required @property (nonatomic, strong) UIColor * _Nullable highlightCircleStrokeColor;
		[Abstract]
		[NullAllowed, Export("highlightCircleStrokeColor", ArgumentSemantic.Strong)]
		UIColor HighlightCircleStrokeColor { get; set; }

		// @required @property (nonatomic) CGFloat highlightCircleStrokeAlpha;
		[Abstract]
		[Export("highlightCircleStrokeAlpha")]
		nfloat HighlightCircleStrokeAlpha { get; set; }

		// @required @property (nonatomic) CGFloat highlightCircleInnerRadius;
		[Abstract]
		[Export("highlightCircleInnerRadius")]
		nfloat HighlightCircleInnerRadius { get; set; }

		// @required @property (nonatomic) CGFloat highlightCircleOuterRadius;
		[Abstract]
		[Export("highlightCircleOuterRadius")]
		nfloat HighlightCircleOuterRadius { get; set; }

		// @required @property (nonatomic) CGFloat highlightCircleStrokeWidth;
		[Abstract]
		[Export("highlightCircleStrokeWidth")]
		nfloat HighlightCircleStrokeWidth { get; set; }
	}

	// @protocol IScatterChartDataSet <ILineScatterCandleRadarChartDataSet>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
	[Protocol(Name = "_TtP6Charts20IScatterChartDataSet_")]
	interface IScatterChartDataSet : ILineScatterCandleRadarChartDataSet
	{
		// @required @property (readonly, nonatomic) CGFloat scatterShapeSize;
		[Abstract]
		[Export("scatterShapeSize")]
		nfloat ScatterShapeSize { get; }

		// @required @property (readonly, nonatomic) CGFloat scatterShapeHoleRadius;
		[Abstract]
		[Export("scatterShapeHoleRadius")]
		nfloat ScatterShapeHoleRadius { get; }

		// @required @property (readonly, nonatomic, strong) UIColor * _Nullable scatterShapeHoleColor;
		[Abstract]
		[NullAllowed, Export("scatterShapeHoleColor", ArgumentSemantic.Strong)]
		UIColor ScatterShapeHoleColor { get; }

		// @required @property (readonly, nonatomic, strong) id<IShapeRenderer> _Nullable shapeRenderer;
		[Abstract]
		[NullAllowed, Export("shapeRenderer", ArgumentSemantic.Strong)]
		IShapeRenderer ShapeRenderer { get; }
	}

	// @interface ChartIndexAxisValueFormatter : NSObject <IChartAxisValueFormatter>
	[BaseType(typeof(NSObject))]
	interface ChartIndexAxisValueFormatter : IChartAxisValueFormatter
	{
		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull values;
		[Export("values", ArgumentSemantic.Copy)]
		string[] Values { get; set; }

		// -(instancetype _Nonnull)initWithValues:(NSArray<NSString *> * _Nonnull)values __attribute__((objc_designated_initializer));
		[Export("initWithValues:")]
		[DesignatedInitializer]
		IntPtr Constructor(string[] values);

		// +(ChartIndexAxisValueFormatter * _Nullable)withValues:(NSArray<NSString *> * _Nonnull)values __attribute__((warn_unused_result));
		[Static]
		[Export("withValues:")]
		[return: NullAllowed]
		ChartIndexAxisValueFormatter WithValues(string[] values);

		// -(NSString * _Nonnull)stringForValue:(double)value axis:(ChartAxisBase * _Nullable)axis __attribute__((warn_unused_result));
		[Export("stringForValue:axis:")]
		string StringForValue(double value, [NullAllowed] ChartAxisBase axis);
	}

	// @interface ChartLegend : ChartComponentBase
	[BaseType(typeof(ChartComponentBase))]
	interface ChartLegend
	{
		// @property (copy, nonatomic) NSArray<ChartLegendEntry *> * _Nonnull entries;
		[Export("entries", ArgumentSemantic.Copy)]
		ChartLegendEntry[] Entries { get; set; }

		// @property (copy, nonatomic) NSArray<ChartLegendEntry *> * _Nonnull extraEntries;
		[Export("extraEntries", ArgumentSemantic.Copy)]
		ChartLegendEntry[] ExtraEntries { get; set; }

		// @property (nonatomic) enum ChartLegendHorizontalAlignment horizontalAlignment;
		[Export("horizontalAlignment", ArgumentSemantic.Assign)]
		ChartLegendHorizontalAlignment HorizontalAlignment { get; set; }

		// @property (nonatomic) enum ChartLegendVerticalAlignment verticalAlignment;
		[Export("verticalAlignment", ArgumentSemantic.Assign)]
		ChartLegendVerticalAlignment VerticalAlignment { get; set; }

		// @property (nonatomic) enum ChartLegendOrientation orientation;
		[Export("orientation", ArgumentSemantic.Assign)]
		ChartLegendOrientation Orientation { get; set; }

		// @property (nonatomic) BOOL drawInside;
		[Export("drawInside")]
		bool DrawInside { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawInsideEnabled;
		[Export("isDrawInsideEnabled")]
		bool IsDrawInsideEnabled { get; }

		// @property (nonatomic) enum ChartLegendDirection direction;
		[Export("direction", ArgumentSemantic.Assign)]
		ChartLegendDirection Direction { get; set; }

		// @property (nonatomic, strong) UIFont * _Nonnull font;
		[Export("font", ArgumentSemantic.Strong)]
		UIFont Font { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic) enum ChartLegendForm form;
		[Export("form", ArgumentSemantic.Assign)]
		ChartLegendForm Form { get; set; }

		// @property (nonatomic) CGFloat formSize;
		[Export("formSize")]
		nfloat FormSize { get; set; }

		// @property (nonatomic) CGFloat formLineWidth;
		[Export("formLineWidth")]
		nfloat FormLineWidth { get; set; }

		// @property (nonatomic) CGFloat formLineDashPhase;
		[Export("formLineDashPhase")]
		nfloat FormLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable formLineDashLengths;
		[NullAllowed, Export("formLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] FormLineDashLengths { get; set; }

		// @property (nonatomic) CGFloat xEntrySpace;
		[Export("xEntrySpace")]
		nfloat XEntrySpace { get; set; }

		// @property (nonatomic) CGFloat yEntrySpace;
		[Export("yEntrySpace")]
		nfloat YEntrySpace { get; set; }

		// @property (nonatomic) CGFloat formToTextSpace;
		[Export("formToTextSpace")]
		nfloat FormToTextSpace { get; set; }

		// @property (nonatomic) CGFloat stackSpace;
		[Export("stackSpace")]
		nfloat StackSpace { get; set; }

		// @property (copy, nonatomic) NSArray<NSValue *> * _Nonnull calculatedLabelSizes;
		[Export("calculatedLabelSizes", ArgumentSemantic.Copy)]
		NSValue[] CalculatedLabelSizes { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nonnull calculatedLabelBreakPoints;
		[Export("calculatedLabelBreakPoints", ArgumentSemantic.Copy)]
		NSNumber[] CalculatedLabelBreakPoints { get; set; }

		// @property (copy, nonatomic) NSArray<NSValue *> * _Nonnull calculatedLineSizes;
		[Export("calculatedLineSizes", ArgumentSemantic.Copy)]
		NSValue[] CalculatedLineSizes { get; set; }

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartLegendEntry *> * _Nonnull)entries __attribute__((objc_designated_initializer));
		[Export("initWithEntries:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartLegendEntry[] entries);

		// -(CGSize)getMaximumEntrySizeWithFont:(UIFont * _Nonnull)font __attribute__((warn_unused_result));
		[Export("getMaximumEntrySizeWithFont:")]
		CGSize GetMaximumEntrySizeWithFont(UIFont font);

		// @property (nonatomic) CGFloat neededWidth;
		[Export("neededWidth")]
		nfloat NeededWidth { get; set; }

		// @property (nonatomic) CGFloat neededHeight;
		[Export("neededHeight")]
		nfloat NeededHeight { get; set; }

		// @property (nonatomic) CGFloat textWidthMax;
		[Export("textWidthMax")]
		nfloat TextWidthMax { get; set; }

		// @property (nonatomic) CGFloat textHeightMax;
		[Export("textHeightMax")]
		nfloat TextHeightMax { get; set; }

		// @property (nonatomic) BOOL wordWrapEnabled;
		[Export("wordWrapEnabled")]
		bool WordWrapEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isWordWrapEnabled;
		[Export("isWordWrapEnabled")]
		bool IsWordWrapEnabled { get; }

		// @property (nonatomic) CGFloat maxSizePercent;
		[Export("maxSizePercent")]
		nfloat MaxSizePercent { get; set; }

		// -(void)calculateDimensionsWithLabelFont:(UIFont * _Nonnull)labelFont viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler;
		[Export("calculateDimensionsWithLabelFont:viewPortHandler:")]
		void CalculateDimensionsWithLabelFont(UIFont labelFont, ChartViewPortHandler viewPortHandler);

		// -(void)setCustomWithEntries:(NSArray<ChartLegendEntry *> * _Nonnull)entries;
		[Export("setCustomWithEntries:")]
		void SetCustomWithEntries(ChartLegendEntry[] entries);

		// -(void)resetCustom;
		[Export("resetCustom")]
		void ResetCustom();

		// @property (readonly, nonatomic) BOOL isLegendCustom;
		[Export("isLegendCustom")]
		bool IsLegendCustom { get; }
	}

	// @interface ChartLegendEntry : NSObject
	[BaseType(typeof(NSObject))]
	interface ChartLegendEntry
	{
		// -(instancetype _Nonnull)initWithLabel:(NSString * _Nullable)label form:(enum ChartLegendForm)form formSize:(CGFloat)formSize formLineWidth:(CGFloat)formLineWidth formLineDashPhase:(CGFloat)formLineDashPhase formLineDashLengths:(NSArray<NSNumber *> * _Nullable)formLineDashLengths formColor:(UIColor * _Nullable)formColor __attribute__((objc_designated_initializer));
		[Export("initWithLabel:form:formSize:formLineWidth:formLineDashPhase:formLineDashLengths:formColor:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] string label, ChartLegendForm form, nfloat formSize, nfloat formLineWidth, nfloat formLineDashPhase, [NullAllowed] NSNumber[] formLineDashLengths, [NullAllowed] UIColor formColor);

		// @property (copy, nonatomic) NSString * _Nullable label;
		[NullAllowed, Export("label")]
		string Label { get; set; }

		// @property (nonatomic) enum ChartLegendForm form;
		[Export("form", ArgumentSemantic.Assign)]
		ChartLegendForm Form { get; set; }

		// @property (nonatomic) CGFloat formSize;
		[Export("formSize")]
		nfloat FormSize { get; set; }

		// @property (nonatomic) CGFloat formLineWidth;
		[Export("formLineWidth")]
		nfloat FormLineWidth { get; set; }

		// @property (nonatomic) CGFloat formLineDashPhase;
		[Export("formLineDashPhase")]
		nfloat FormLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable formLineDashLengths;
		[NullAllowed, Export("formLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] FormLineDashLengths { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable formColor;
		[NullAllowed, Export("formColor", ArgumentSemantic.Strong)]
		UIColor FormColor { get; set; }
	}

	// @interface ChartLegendRenderer : ChartRenderer
	[BaseType(typeof(ChartRenderer))]
	interface ChartLegendRenderer
	{
		// @property (nonatomic, strong) ChartLegend * _Nullable legend;
		[NullAllowed, Export("legend", ArgumentSemantic.Strong)]
		ChartLegend Legend { get; set; }

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler legend:(ChartLegend * _Nullable)legend __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:legend:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartLegend legend);

		// -(void)computeLegendWithData:(ChartData * _Nonnull)data;
		[Export("computeLegendWithData:")]
		void ComputeLegendWithData(ChartData data);

		// -(void)renderLegendWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLegendWithContext:")]
		unsafe void RenderLegendWithContext(CGContext context);

		// -(void)drawFormWithContext:(CGContextRef _Nonnull)context x:(CGFloat)x y:(CGFloat)y entry:(ChartLegendEntry * _Nonnull)entry legend:(ChartLegend * _Nonnull)legend;
		[Export("drawFormWithContext:x:y:entry:legend:")]
		unsafe void DrawFormWithContext(CGContext context, nfloat x, nfloat y, ChartLegendEntry entry, ChartLegend legend);

		// -(void)drawLabelWithContext:(CGContextRef _Nonnull)context x:(CGFloat)x y:(CGFloat)y label:(NSString * _Nonnull)label font:(UIFont * _Nonnull)font textColor:(UIColor * _Nonnull)textColor;
		[Export("drawLabelWithContext:x:y:label:font:textColor:")]
		unsafe void DrawLabelWithContext(CGContext context, nfloat x, nfloat y, string label, UIFont font, UIColor textColor);
	}

	// @interface LineChartData : ChartData
	[BaseType(typeof(ChartData), Name = "_TtC6Charts13LineChartData")]
	interface LineChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);
	}

	// @interface LineRadarChartDataSet : LineScatterCandleRadarChartDataSet <ILineRadarChartDataSet>
	[BaseType(typeof(LineScatterCandleRadarChartDataSet), Name = "_TtC6Charts21LineRadarChartDataSet")]
	interface LineRadarChartDataSet : ILineRadarChartDataSet
	{
		// @property (nonatomic, strong) UIColor * _Nonnull fillColor;
		[Export("fillColor", ArgumentSemantic.Strong)]
		UIColor FillColor { get; set; }

		// @property (nonatomic, strong) ChartFill * _Nullable fill;
		[NullAllowed, Export("fill", ArgumentSemantic.Strong)]
		ChartFill Fill { get; set; }

		// @property (nonatomic) CGFloat fillAlpha;
		[Export("fillAlpha")]
		nfloat FillAlpha { get; set; }

		// @property (nonatomic) CGFloat lineWidth;
		[Export("lineWidth")]
		nfloat LineWidth { get; set; }

		// @property (nonatomic) BOOL drawFilledEnabled;
		[Export("drawFilledEnabled")]
		bool DrawFilledEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawFilledEnabled;
		[Export("isDrawFilledEnabled")]
		bool IsDrawFilledEnabled { get; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);
	}

	// @interface LineChartDataSet : LineRadarChartDataSet <ILineChartDataSet>
	[BaseType(typeof(LineRadarChartDataSet), Name = "_TtC6Charts16LineChartDataSet")]
	interface LineChartDataSet : ILineChartDataSet
	{
		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// @property (nonatomic) enum LineChartMode mode;
		[Export("mode", ArgumentSemantic.Assign)]
		LineChartMode Mode { get; set; }

		// @property (nonatomic) CGFloat cubicIntensity;
		[Export("cubicIntensity")]
		nfloat CubicIntensity { get; set; }

		// @property (nonatomic) CGFloat circleRadius;
		[Export("circleRadius")]
		nfloat CircleRadius { get; set; }

		// @property (nonatomic) CGFloat circleHoleRadius;
		[Export("circleHoleRadius")]
		nfloat CircleHoleRadius { get; set; }

		// @property (copy, nonatomic) NSArray<UIColor *> * _Nonnull circleColors;
		[Export("circleColors", ArgumentSemantic.Copy)]
		UIColor[] CircleColors { get; set; }

		// -(UIColor * _Nullable)getCircleColorAtIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("getCircleColorAtIndex:")]
		[return: NullAllowed]
		UIColor GetCircleColorAtIndex(nint index);

		// -(void)setCircleColor:(UIColor * _Nonnull)color;
		[Export("setCircleColor:")]
		void SetCircleColor(UIColor color);

		// -(void)resetCircleColors:(NSInteger)index;
		[Export("resetCircleColors:")]
		void ResetCircleColors(nint index);

		// @property (nonatomic) BOOL drawCirclesEnabled;
		[Export("drawCirclesEnabled")]
		bool DrawCirclesEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawCirclesEnabled;
		[Export("isDrawCirclesEnabled")]
		bool IsDrawCirclesEnabled { get; }

		// @property (nonatomic, strong) UIColor * _Nullable circleHoleColor;
		[NullAllowed, Export("circleHoleColor", ArgumentSemantic.Strong)]
		UIColor CircleHoleColor { get; set; }

		// @property (nonatomic) BOOL drawCircleHoleEnabled;
		[Export("drawCircleHoleEnabled")]
		bool DrawCircleHoleEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawCircleHoleEnabled;
		[Export("isDrawCircleHoleEnabled")]
		bool IsDrawCircleHoleEnabled { get; }

		// @property (nonatomic) CGFloat lineDashPhase;
		[Export("lineDashPhase")]
		nfloat LineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable lineDashLengths;
		[NullAllowed, Export("lineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] LineDashLengths { get; set; }

		// @property (nonatomic) CGLineCap lineCapType;
		[Export("lineCapType", ArgumentSemantic.Assign)]
		CGLineCap LineCapType { get; set; }

		// @property (nonatomic, strong) id<IChartFillFormatter> _Nullable fillFormatter;
		[NullAllowed, Export("fillFormatter", ArgumentSemantic.Strong)]
		IChartFillFormatter FillFormatter { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface LineRadarChartRenderer : LineScatterCandleRadarChartRenderer
	[BaseType(typeof(LineScatterCandleRadarChartRenderer))]
	interface LineRadarChartRenderer
	{
		// -(instancetype _Nonnull)initWithAnimator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithAnimator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawFilledPathWithContext:(CGContextRef _Nonnull)context path:(CGPathRef _Nonnull)path fill:(ChartFill * _Nonnull)fill fillAlpha:(CGFloat)fillAlpha;
		[Export("drawFilledPathWithContext:path:fill:fillAlpha:")]
		unsafe void DrawFilledPathWithContext(CGContext context, CGPath path, ChartFill fill, nfloat fillAlpha);

		// -(void)drawFilledPathWithContext:(CGContextRef _Nonnull)context path:(CGPathRef _Nonnull)path fillColor:(UIColor * _Nonnull)fillColor fillAlpha:(CGFloat)fillAlpha;
		[Export("drawFilledPathWithContext:path:fillColor:fillAlpha:")]
		unsafe void DrawFilledPathWithContext(CGContext context, CGPath path, UIColor fillColor, nfloat fillAlpha);
	}

	// @interface LineChartRenderer : LineRadarChartRenderer
	[BaseType(typeof(LineRadarChartRenderer), Name = "_TtC6Charts17LineChartRenderer")]
	interface LineChartRenderer
	{
		// @property (nonatomic, weak) id<LineChartDataProvider> _Nullable dataProvider;
		[NullAllowed, Export("dataProvider", ArgumentSemantic.Weak)]
		LineChartDataProvider DataProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataProvider:(id<LineChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(LineChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<ILineChartDataSet> _Nonnull)dataSet;
		[Export("drawDataSetWithContext:dataSet:")]
		unsafe void DrawDataSetWithContext(CGContext context, ILineChartDataSet dataSet);

		// -(void)drawCubicBezierWithContext:(CGContextRef _Nonnull)context dataSet:(id<ILineChartDataSet> _Nonnull)dataSet;
		[Export("drawCubicBezierWithContext:dataSet:")]
		unsafe void DrawCubicBezierWithContext(CGContext context, ILineChartDataSet dataSet);

		// -(void)drawHorizontalBezierWithContext:(CGContextRef _Nonnull)context dataSet:(id<ILineChartDataSet> _Nonnull)dataSet;
		[Export("drawHorizontalBezierWithContext:dataSet:")]
		unsafe void DrawHorizontalBezierWithContext(CGContext context, ILineChartDataSet dataSet);

		// -(void)drawLinearWithContext:(CGContextRef _Nonnull)context dataSet:(id<ILineChartDataSet> _Nonnull)dataSet;
		[Export("drawLinearWithContext:dataSet:")]
		unsafe void DrawLinearWithContext(CGContext context, ILineChartDataSet dataSet);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface LineChartView : BarLineChartViewBase <LineChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts13LineChartView")]
	interface LineChartView : LineChartDataProvider
	{
		// @property (readonly, nonatomic, strong) LineChartData * _Nullable lineData;
		[NullAllowed, Export("lineData", ArgumentSemantic.Strong)]
		LineChartData LineData { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface ChartMarkerImage : NSObject <IChartMarker>
	[BaseType(typeof(NSObject))]
	interface ChartMarkerImage : IChartMarker
	{
		// @property (nonatomic, strong) UIImage * _Nullable image;
		[NullAllowed, Export("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (nonatomic) CGPoint offset;
		[Export("offset", ArgumentSemantic.Assign)]
		CGPoint Offset { get; set; }

		// @property (nonatomic, weak) ChartViewBase * _Nullable chartView;
		[NullAllowed, Export("chartView", ArgumentSemantic.Weak)]
		ChartViewBase ChartView { get; set; }

		// @property (nonatomic) CGSize size;
		[Export("size", ArgumentSemantic.Assign)]
		CGSize Size { get; set; }

		// -(CGPoint)offsetForDrawingAtPoint:(CGPoint)point __attribute__((warn_unused_result));
		[Export("offsetForDrawingAtPoint:")]
		CGPoint OffsetForDrawingAtPoint(CGPoint point);

		// -(void)refreshContentWithEntry:(ChartDataEntry * _Nonnull)entry highlight:(ChartHighlight * _Nonnull)highlight;
		[Export("refreshContentWithEntry:highlight:")]
		void RefreshContentWithEntry(ChartDataEntry entry, ChartHighlight highlight);

		// -(void)drawWithContext:(CGContextRef _Nonnull)context point:(CGPoint)point;
		[Export("drawWithContext:point:")]
		unsafe void DrawWithContext(CGContext context, CGPoint point);
	}

	// @interface ChartMarkerView : NSUIView <IChartMarker>
	[BaseType(typeof(NSUIView))]
	interface ChartMarkerView : IChartMarker
	{
		// @property (nonatomic) CGPoint offset;
		[Export("offset", ArgumentSemantic.Assign)]
		CGPoint Offset { get; set; }

		// @property (nonatomic, weak) ChartViewBase * _Nullable chartView;
		[NullAllowed, Export("chartView", ArgumentSemantic.Weak)]
		ChartViewBase ChartView { get; set; }

		// -(CGPoint)offsetForDrawingAtPoint:(CGPoint)point __attribute__((warn_unused_result));
		[Export("offsetForDrawingAtPoint:")]
		CGPoint OffsetForDrawingAtPoint(CGPoint point);

		// -(void)refreshContentWithEntry:(ChartDataEntry * _Nonnull)entry highlight:(ChartHighlight * _Nonnull)highlight;
		[Export("refreshContentWithEntry:highlight:")]
		void RefreshContentWithEntry(ChartDataEntry entry, ChartHighlight highlight);

		// -(void)drawWithContext:(CGContextRef _Nonnull)context point:(CGPoint)point;
		[Export("drawWithContext:point:")]
		unsafe void DrawWithContext(CGContext context, CGPoint point);

		// +(ChartMarkerView * _Nullable)viewFromXibIn:(NSBundle * _Nonnull)bundle __attribute__((warn_unused_result));
		[Static]
		[Export("viewFromXibIn:")]
		[return: NullAllowed]
		ChartMarkerView ViewFromXibIn(NSBundle bundle);

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder coder);
	}

	// @interface MoveChartViewJob : ChartViewPortJob
	[BaseType(typeof(ChartViewPortJob))]
	interface MoveChartViewJob
	{
		// -(void)doJob;
		[Export("doJob")]
		void DoJob();

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xValue:(double)xValue yValue:(double)yValue transformer:(ChartTransformer * _Nonnull)transformer view:(ChartViewBase * _Nonnull)view __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xValue:yValue:transformer:view:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, double xValue, double yValue, ChartTransformer transformer, ChartViewBase view);
	}

	// @interface NSUIAccessibilityElement : UIAccessibilityElement
	[BaseType(typeof(UIAccessibilityElement), Name = "_TtC6Charts24NSUIAccessibilityElement")]
	[DisableDefaultCtor]
	interface NSUIAccessibilityElement
	{
		// -(instancetype _Nonnull)initWithAccessibilityContainer:(id _Nonnull)container __attribute__((objc_designated_initializer));
		[Export("initWithAccessibilityContainer:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSObject container);

		// @property (nonatomic) CGRect accessibilityFrame;
		[Export("accessibilityFrame", ArgumentSemantic.Assign)]
		CGRect AccessibilityFrame { get; set; }
	}

	// @interface Charts_Swift_3730 (NSUIView)
	[Category]
	[BaseType(typeof(NSUIView))]
	interface NSUIView_Charts_Swift_3730
	{
		// -(void)touchesBegan:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("touchesBegan:withEvent:")]
		void TouchesBegan(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesMoved:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("touchesMoved:withEvent:")]
		void TouchesMoved(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesEnded:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("touchesEnded:withEvent:")]
		void TouchesEnded(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)touchesCancelled:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("touchesCancelled:withEvent:")]
		void TouchesCancelled(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesBegan:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesBegan:withEvent:")]
		void NsuiTouchesBegan(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesMoved:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesMoved:withEvent:")]
		void NsuiTouchesMoved(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesEnded:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesEnded:withEvent:")]
		void NsuiTouchesEnded(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesCancelled:(NSSet<UITouch *> * _Nullable)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesCancelled:withEvent:")]
		void NsuiTouchesCancelled([NullAllowed] NSSet<UITouch> touches, [NullAllowed] UIEvent @event);
	}

	// @interface Charts_Swift_3742 (NSUIView)
	[Category]
	[BaseType(typeof(NSUIView))]
	interface NSUIView_Charts_Swift_3742
	{
		// -(NSArray * _Nullable)accessibilityChildren __attribute__((warn_unused_result));
		[NullAllowed, Export("accessibilityChildren")]
		NSObject[] AccessibilityChildren { get; }

		// @property (nonatomic) BOOL isAccessibilityElement;
		[Export("isAccessibilityElement")]
		bool IsAccessibilityElement { get; set; }

		// -(NSInteger)accessibilityElementCount __attribute__((warn_unused_result));
		[Export("accessibilityElementCount")]

		nint AccessibilityElementCount { get; }

		// -(id _Nullable)accessibilityElementAtIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("accessibilityElementAtIndex:")]
		[return: NullAllowed]
		NSObject AccessibilityElementAtIndex(nint index);

		// -(NSInteger)indexOfAccessibilityElement:(id _Nonnull)element __attribute__((warn_unused_result));
		[Export("indexOfAccessibilityElement:")]
		nint IndexOfAccessibilityElement(NSObject element);
	}

	// @interface PieChartData : ChartData
	[BaseType(typeof(ChartData), Name = "_TtC6Charts12PieChartData")]
	interface PieChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// @property (copy, nonatomic) NSArray<id<IChartDataSet>> * _Nonnull dataSets;
		[Export("dataSets", ArgumentSemantic.Copy)]
		IChartDataSet[] DataSets { get; set; }

		// @property (nonatomic, strong) id<IPieChartDataSet> _Nullable dataSet;
		[NullAllowed, Export("dataSet", ArgumentSemantic.Strong)]
		IPieChartDataSet DataSet { get; set; }

		// -(id<IChartDataSet> _Nullable)getDataSetByIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("getDataSetByIndex:")]
		[return: NullAllowed]
		IChartDataSet GetDataSetByIndex(nint index);

		// -(id<IChartDataSet> _Nullable)getDataSetByLabel:(NSString * _Nonnull)label ignorecase:(BOOL)ignorecase __attribute__((warn_unused_result));
		[Export("getDataSetByLabel:ignorecase:")]
		[return: NullAllowed]
		IChartDataSet GetDataSetByLabel(string label, bool ignorecase);

		// -(ChartDataEntry * _Nullable)entryForHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("entryForHighlight:")]
		[return: NullAllowed]
		ChartDataEntry EntryForHighlight(ChartHighlight highlight);

		// -(void)addDataSet:(id<IChartDataSet> _Null_unspecified)d;
		[Export("addDataSet:")]
		void AddDataSet(IChartDataSet d);

		// -(BOOL)removeDataSetByIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("removeDataSetByIndex:")]
		bool RemoveDataSetByIndex(nint index);

		// @property (readonly, nonatomic) double yValueSum;
		[Export("yValueSum")]
		double YValueSum { get; }
	}

	// @interface PieChartDataEntry : ChartDataEntry
	[BaseType(typeof(ChartDataEntry), Name = "_TtC6Charts17PieChartDataEntry")]
	interface PieChartDataEntry
	{
		// -(instancetype _Nonnull)initWithValue:(double)value __attribute__((objc_designated_initializer));
		[Export("initWithValue:")]
		[DesignatedInitializer]
		IntPtr Constructor(double value);

		// -(instancetype _Nonnull)initWithValue:(double)value label:(NSString * _Nullable)label;
		[Export("initWithValue:label:")]
		IntPtr Constructor(double value, [NullAllowed] string label);

		// -(instancetype _Nonnull)initWithValue:(double)value label:(NSString * _Nullable)label data:(id _Nullable)data;
		[Export("initWithValue:label:data:")]
		IntPtr Constructor(double value, [NullAllowed] string label, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithValue:(double)value label:(NSString * _Nullable)label icon:(UIImage * _Nullable)icon;
		[Export("initWithValue:label:icon:")]
		IntPtr Constructor(double value, [NullAllowed] string label, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithValue:(double)value label:(NSString * _Nullable)label icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithValue:label:icon:data:")]
		IntPtr Constructor(double value, [NullAllowed] string label, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithValue:(double)value data:(id _Nullable)data;
		[Export("initWithValue:data:")]
		IntPtr Constructor(double value, [NullAllowed] NSObject data);

		// -(instancetype _Nonnull)initWithValue:(double)value icon:(UIImage * _Nullable)icon;
		[Export("initWithValue:icon:")]
		IntPtr Constructor(double value, [NullAllowed] UIImage icon);

		// -(instancetype _Nonnull)initWithValue:(double)value icon:(UIImage * _Nullable)icon data:(id _Nullable)data;
		[Export("initWithValue:icon:data:")]
		IntPtr Constructor(double value, [NullAllowed] UIImage icon, [NullAllowed] NSObject data);

		// @property (copy, nonatomic) NSString * _Nullable label;
		[NullAllowed, Export("label")]
		string Label { get; set; }

		// @property (nonatomic) double value;
		[Export("value")]
		double Value { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface PieChartDataSet : ChartDataSet <IPieChartDataSet>
	[BaseType(typeof(ChartDataSet), Name = "_TtC6Charts15PieChartDataSet")]
	interface PieChartDataSet : IPieChartDataSet
	{
		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// @property (nonatomic) CGFloat sliceSpace;
		[Export("sliceSpace")]
		nfloat SliceSpace { get; set; }

		// @property (nonatomic) BOOL automaticallyDisableSliceSpacing;
		[Export("automaticallyDisableSliceSpacing")]
		bool AutomaticallyDisableSliceSpacing { get; set; }

		// @property (nonatomic) CGFloat selectionShift;
		[Export("selectionShift")]
		nfloat SelectionShift { get; set; }

		// @property (nonatomic) enum PieChartValuePosition xValuePosition;
		[Export("xValuePosition", ArgumentSemantic.Assign)]
		PieChartValuePosition XValuePosition { get; set; }

		// @property (nonatomic) enum PieChartValuePosition yValuePosition;
		[Export("yValuePosition", ArgumentSemantic.Assign)]
		PieChartValuePosition YValuePosition { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable valueLineColor;
		[NullAllowed, Export("valueLineColor", ArgumentSemantic.Strong)]
		UIColor ValueLineColor { get; set; }

		// @property (nonatomic) BOOL useValueColorForLine;
		[Export("useValueColorForLine")]
		bool UseValueColorForLine { get; set; }

		// @property (nonatomic) CGFloat valueLineWidth;
		[Export("valueLineWidth")]
		nfloat ValueLineWidth { get; set; }

		// @property (nonatomic) CGFloat valueLinePart1OffsetPercentage;
		[Export("valueLinePart1OffsetPercentage")]
		nfloat ValueLinePart1OffsetPercentage { get; set; }

		// @property (nonatomic) CGFloat valueLinePart1Length;
		[Export("valueLinePart1Length")]
		nfloat ValueLinePart1Length { get; set; }

		// @property (nonatomic) CGFloat valueLinePart2Length;
		[Export("valueLinePart2Length")]
		nfloat ValueLinePart2Length { get; set; }

		// @property (nonatomic) BOOL valueLineVariableLength;
		[Export("valueLineVariableLength")]
		bool ValueLineVariableLength { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable entryLabelFont;
		[NullAllowed, Export("entryLabelFont", ArgumentSemantic.Strong)]
		UIFont EntryLabelFont { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable entryLabelColor;
		[NullAllowed, Export("entryLabelColor", ArgumentSemantic.Strong)]
		UIColor EntryLabelColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable highlightColor;
		[NullAllowed, Export("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface PieChartRenderer : ChartDataRendererBase
	[BaseType(typeof(ChartDataRendererBase), Name = "_TtC6Charts16PieChartRenderer")]
	interface PieChartRenderer
	{
		// @property (nonatomic, weak) PieChartView * _Nullable chart;
		[NullAllowed, Export("chart", ArgumentSemantic.Weak)]
		PieChartView Chart { get; set; }

		// -(instancetype _Nonnull)initWithChart:(PieChartView * _Nonnull)chart animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithChart:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(PieChartView chart, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(CGFloat)calculateMinimumRadiusForSpacedSliceWithCenter:(CGPoint)center radius:(CGFloat)radius angle:(CGFloat)angle arcStartPointX:(CGFloat)arcStartPointX arcStartPointY:(CGFloat)arcStartPointY startAngle:(CGFloat)startAngle sweepAngle:(CGFloat)sweepAngle __attribute__((warn_unused_result));
		[Export("calculateMinimumRadiusForSpacedSliceWithCenter:radius:angle:arcStartPointX:arcStartPointY:startAngle:sweepAngle:")]
		nfloat CalculateMinimumRadiusForSpacedSliceWithCenter(CGPoint center, nfloat radius, nfloat angle, nfloat arcStartPointX, nfloat arcStartPointY, nfloat startAngle, nfloat sweepAngle);

		// -(CGFloat)getSliceSpaceWithDataSet:(id<IPieChartDataSet> _Nonnull)dataSet __attribute__((warn_unused_result));
		[Export("getSliceSpaceWithDataSet:")]
		nfloat GetSliceSpaceWithDataSet(IPieChartDataSet dataSet);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<IPieChartDataSet> _Nonnull)dataSet;
		[Export("drawDataSetWithContext:dataSet:")]
		unsafe void DrawDataSetWithContext(CGContext context, IPieChartDataSet dataSet);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface PieRadarChartViewBase : ChartViewBase
	[BaseType(typeof(ChartViewBase), Name = "_TtC6Charts21PieRadarChartViewBase")]
	interface PieRadarChartViewBase
	{
		// @property (nonatomic) BOOL rotationEnabled;
		[Export("rotationEnabled")]
		bool RotationEnabled { get; set; }

		// @property (nonatomic) CGFloat minOffset;
		[Export("minOffset")]
		nfloat MinOffset { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// @property (readonly, nonatomic) NSInteger maxVisibleCount;
		[Export("maxVisibleCount")]
		nint MaxVisibleCount { get; }

		// -(void)notifyDataSetChanged;
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// -(CGFloat)angleForPointWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("angleForPointWithX:y:")]
		nfloat AngleForPointWithX(nfloat x, nfloat y);

		// -(CGPoint)getPositionWithCenter:(CGPoint)center dist:(CGFloat)dist angle:(CGFloat)angle __attribute__((warn_unused_result));
		[Export("getPositionWithCenter:dist:angle:")]
		CGPoint GetPositionWithCenter(CGPoint center, nfloat dist, nfloat angle);

		// -(CGFloat)distanceToCenterWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("distanceToCenterWithX:y:")]
		nfloat DistanceToCenterWithX(nfloat x, nfloat y);

		// -(NSInteger)indexForAngle:(CGFloat)angle __attribute__((warn_unused_result));
		[Export("indexForAngle:")]
		nint IndexForAngle(nfloat angle);

		// @property (nonatomic) CGFloat rotationAngle;
		[Export("rotationAngle")]
		nfloat RotationAngle { get; set; }

		// @property (readonly, nonatomic) CGFloat rawRotationAngle;
		[Export("rawRotationAngle")]
		nfloat RawRotationAngle { get; }

		// @property (readonly, nonatomic) CGFloat diameter;
		[Export("diameter")]
		nfloat Diameter { get; }

		// @property (readonly, nonatomic) CGFloat radius;
		[Export("radius")]
		nfloat Radius { get; }

		// @property (readonly, nonatomic) double chartYMax;
		[Export("chartYMax")]
		double ChartYMax { get; }

		// @property (readonly, nonatomic) double chartYMin;
		[Export("chartYMin")]
		double ChartYMin { get; }

		// @property (readonly, nonatomic) BOOL isRotationEnabled;
		[Export("isRotationEnabled")]
		bool IsRotationEnabled { get; }

		// @property (nonatomic) BOOL rotationWithTwoFingers;
		[Export("rotationWithTwoFingers")]
		bool RotationWithTwoFingers { get; set; }

		// @property (readonly, nonatomic) BOOL isRotationWithTwoFingers;
		[Export("isRotationWithTwoFingers")]
		bool IsRotationWithTwoFingers { get; }

		// -(void)spinWithDuration:(NSTimeInterval)duration fromAngle:(CGFloat)fromAngle toAngle:(CGFloat)toAngle easing:(double (^ _Nullable)(NSTimeInterval, NSTimeInterval))easing;
		[Export("spinWithDuration:fromAngle:toAngle:easing:")]
		void SpinWithDuration(double duration, nfloat fromAngle, nfloat toAngle, [NullAllowed] Func<double, double, double> easing);

		// -(void)spinWithDuration:(NSTimeInterval)duration fromAngle:(CGFloat)fromAngle toAngle:(CGFloat)toAngle easingOption:(enum ChartEasingOption)easingOption;
		[Export("spinWithDuration:fromAngle:toAngle:easingOption:")]
		void SpinWithDuration(double duration, nfloat fromAngle, nfloat toAngle, ChartEasingOption easingOption);

		// -(void)spinWithDuration:(NSTimeInterval)duration fromAngle:(CGFloat)fromAngle toAngle:(CGFloat)toAngle;
		[Export("spinWithDuration:fromAngle:toAngle:")]
		void SpinWithDuration(double duration, nfloat fromAngle, nfloat toAngle);

		// -(void)stopSpinAnimation;
		[Export("stopSpinAnimation")]
		void StopSpinAnimation();

		// -(void)nsuiTouchesBegan:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesBegan:withEvent:")]
		void NsuiTouchesBegan(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesMoved:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesMoved:withEvent:")]
		void NsuiTouchesMoved(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesEnded:(NSSet<UITouch *> * _Nonnull)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesEnded:withEvent:")]
		void NsuiTouchesEnded(NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)nsuiTouchesCancelled:(NSSet<UITouch *> * _Nullable)touches withEvent:(UIEvent * _Nullable)event;
		[Export("nsuiTouchesCancelled:withEvent:")]
		void NsuiTouchesCancelled([NullAllowed] NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		// -(void)stopDeceleration;
		[Export("stopDeceleration")]
		void StopDeceleration();
	}

	// @interface PieChartView : PieRadarChartViewBase
	[BaseType(typeof(PieRadarChartViewBase), Name = "_TtC6Charts12PieChartView")]
	interface PieChartView
	{
		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// -(CGPoint)getMarkerPositionWithHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("getMarkerPositionWithHighlight:")]
		CGPoint GetMarkerPositionWithHighlight(ChartHighlight highlight);

		// -(BOOL)needsHighlightWithIndex:(NSInteger)index __attribute__((warn_unused_result));
		[Export("needsHighlightWithIndex:")]
		bool NeedsHighlightWithIndex(nint index);

		// @property (readonly, nonatomic, strong) ChartXAxis * _Nonnull xAxis;
		[Export("xAxis", ArgumentSemantic.Strong)]
		ChartXAxis XAxis { get; }

		// -(NSInteger)indexForAngle:(CGFloat)angle __attribute__((warn_unused_result));
		[Export("indexForAngle:")]
		nint IndexForAngle(nfloat angle);

		// -(NSInteger)dataSetIndexForIndex:(double)xValue __attribute__((warn_unused_result));
		[Export("dataSetIndexForIndex:")]
		nint DataSetIndexForIndex(double xValue);

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull drawAngles;
		[Export("drawAngles", ArgumentSemantic.Copy)]
		NSNumber[] DrawAngles { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull absoluteAngles;
		[Export("absoluteAngles", ArgumentSemantic.Copy)]
		NSNumber[] AbsoluteAngles { get; }

		// @property (nonatomic, strong) UIColor * _Nullable holeColor;
		[NullAllowed, Export("holeColor", ArgumentSemantic.Strong)]
		UIColor HoleColor { get; set; }

		// @property (nonatomic) BOOL drawSlicesUnderHoleEnabled;
		[Export("drawSlicesUnderHoleEnabled")]
		bool DrawSlicesUnderHoleEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawSlicesUnderHoleEnabled;
		[Export("isDrawSlicesUnderHoleEnabled")]
		bool IsDrawSlicesUnderHoleEnabled { get; }

		// @property (nonatomic) BOOL drawHoleEnabled;
		[Export("drawHoleEnabled")]
		bool DrawHoleEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawHoleEnabled;
		[Export("isDrawHoleEnabled")]
		bool IsDrawHoleEnabled { get; }

		// @property (copy, nonatomic) NSString * _Nullable centerText;
		[NullAllowed, Export("centerText")]
		string CenterText { get; set; }

		// @property (nonatomic, strong) NSAttributedString * _Nullable centerAttributedText;
		[NullAllowed, Export("centerAttributedText", ArgumentSemantic.Strong)]
		NSAttributedString CenterAttributedText { get; set; }

		// @property (nonatomic) CGPoint centerTextOffset;
		[Export("centerTextOffset", ArgumentSemantic.Assign)]
		CGPoint CenterTextOffset { get; set; }

		// @property (nonatomic) BOOL drawCenterTextEnabled;
		[Export("drawCenterTextEnabled")]
		bool DrawCenterTextEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawCenterTextEnabled;
		[Export("isDrawCenterTextEnabled")]
		bool IsDrawCenterTextEnabled { get; }

		// @property (readonly, nonatomic) CGFloat radius;
		[Export("radius")]
		nfloat Radius { get; }

		// @property (readonly, nonatomic) CGRect circleBox;
		[Export("circleBox")]
		CGRect CircleBox { get; }

		// @property (readonly, nonatomic) CGPoint centerCircleBox;
		[Export("centerCircleBox")]
		CGPoint CenterCircleBox { get; }

		// @property (nonatomic) CGFloat holeRadiusPercent;
		[Export("holeRadiusPercent")]
		nfloat HoleRadiusPercent { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable transparentCircleColor;
		[NullAllowed, Export("transparentCircleColor", ArgumentSemantic.Strong)]
		UIColor TransparentCircleColor { get; set; }

		// @property (nonatomic) CGFloat transparentCircleRadiusPercent;
		[Export("transparentCircleRadiusPercent")]
		nfloat TransparentCircleRadiusPercent { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable entryLabelColor;
		[NullAllowed, Export("entryLabelColor", ArgumentSemantic.Strong)]
		UIColor EntryLabelColor { get; set; }

		// @property (nonatomic, strong) UIFont * _Nullable entryLabelFont;
		[NullAllowed, Export("entryLabelFont", ArgumentSemantic.Strong)]
		UIFont EntryLabelFont { get; set; }

		// @property (nonatomic) BOOL drawEntryLabelsEnabled;
		[Export("drawEntryLabelsEnabled")]
		bool DrawEntryLabelsEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawEntryLabelsEnabled;
		[Export("isDrawEntryLabelsEnabled")]
		bool IsDrawEntryLabelsEnabled { get; }

		// @property (nonatomic) BOOL usePercentValuesEnabled;
		[Export("usePercentValuesEnabled")]
		bool UsePercentValuesEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isUsePercentValuesEnabled;
		[Export("isUsePercentValuesEnabled")]
		bool IsUsePercentValuesEnabled { get; }

		// @property (nonatomic) CGFloat centerTextRadiusPercent;
		[Export("centerTextRadiusPercent")]
		nfloat CenterTextRadiusPercent { get; set; }

		// @property (nonatomic) CGFloat maxAngle;
		[Export("maxAngle")]
		nfloat MaxAngle { get; set; }
	}

	// @interface PieRadarChartHighlighter : ChartHighlighter
	[BaseType(typeof(ChartHighlighter))]
	interface PieRadarChartHighlighter
	{
		// -(ChartHighlight * _Nullable)getHighlightWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("getHighlightWithX:y:")]
		[return: NullAllowed]
		ChartHighlight GetHighlightWithX(nfloat x, nfloat y);

		// -(ChartHighlight * _Nullable)closestHighlightWithIndex:(NSInteger)index x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("closestHighlightWithIndex:x:y:")]
		[return: NullAllowed]
		ChartHighlight ClosestHighlightWithIndex(nint index, nfloat x, nfloat y);

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);
	}

	// @interface PieChartHighlighter : PieRadarChartHighlighter
	[BaseType(typeof(PieRadarChartHighlighter))]
	interface PieChartHighlighter
	{
		// -(ChartHighlight * _Nullable)closestHighlightWithIndex:(NSInteger)index x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("closestHighlightWithIndex:x:y:")]
		[return: NullAllowed]
		ChartHighlight ClosestHighlightWithIndex(nint index, nfloat x, nfloat y);

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);
	}

	// @interface RadarChartData : ChartData
	[BaseType(typeof(ChartData), Name = "_TtC6Charts14RadarChartData")]
	interface RadarChartData
	{
		// @property (nonatomic, strong) UIColor * _Nonnull highlightColor;
		[Export("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }

		// @property (nonatomic) CGFloat highlightLineWidth;
		[Export("highlightLineWidth")]
		nfloat HighlightLineWidth { get; set; }

		// @property (nonatomic) CGFloat highlightLineDashPhase;
		[Export("highlightLineDashPhase")]
		nfloat HighlightLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable highlightLineDashLengths;
		[NullAllowed, Export("highlightLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] HighlightLineDashLengths { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull labels;
		[Export("labels", ArgumentSemantic.Copy)]
		string[] Labels { get; set; }

		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// -(ChartDataEntry * _Nullable)entryForHighlight:(ChartHighlight * _Nonnull)highlight __attribute__((warn_unused_result));
		[Export("entryForHighlight:")]
		[return: NullAllowed]
		ChartDataEntry EntryForHighlight(ChartHighlight highlight);
	}

	// @interface RadarChartDataEntry : ChartDataEntry
	[BaseType(typeof(ChartDataEntry), Name = "_TtC6Charts19RadarChartDataEntry")]
	interface RadarChartDataEntry
	{
		// -(instancetype _Nonnull)initWithValue:(double)value __attribute__((objc_designated_initializer));
		[Export("initWithValue:")]
		[DesignatedInitializer]
		IntPtr Constructor(double value);

		// -(instancetype _Nonnull)initWithValue:(double)value data:(id _Nullable)data;
		[Export("initWithValue:data:")]
		IntPtr Constructor(double value, [NullAllowed] NSObject data);

		// @property (nonatomic) double value;
		[Export("value")]
		double Value { get; set; }

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);
	}

	// @interface RadarChartDataSet : LineRadarChartDataSet <IRadarChartDataSet>
	[BaseType(typeof(LineRadarChartDataSet), Name = "_TtC6Charts17RadarChartDataSet")]
	interface RadarChartDataSet : IRadarChartDataSet
	{
		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);

		// @property (nonatomic) BOOL drawHighlightCircleEnabled;
		[Export("drawHighlightCircleEnabled")]
		bool DrawHighlightCircleEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isDrawHighlightCircleEnabled;
		[Export("isDrawHighlightCircleEnabled")]
		bool IsDrawHighlightCircleEnabled { get; }

		// @property (nonatomic, strong) UIColor * _Nullable highlightCircleFillColor;
		[NullAllowed, Export("highlightCircleFillColor", ArgumentSemantic.Strong)]
		UIColor HighlightCircleFillColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable highlightCircleStrokeColor;
		[NullAllowed, Export("highlightCircleStrokeColor", ArgumentSemantic.Strong)]
		UIColor HighlightCircleStrokeColor { get; set; }

		// @property (nonatomic) CGFloat highlightCircleStrokeAlpha;
		[Export("highlightCircleStrokeAlpha")]
		nfloat HighlightCircleStrokeAlpha { get; set; }

		// @property (nonatomic) CGFloat highlightCircleInnerRadius;
		[Export("highlightCircleInnerRadius")]
		nfloat HighlightCircleInnerRadius { get; set; }

		// @property (nonatomic) CGFloat highlightCircleOuterRadius;
		[Export("highlightCircleOuterRadius")]
		nfloat HighlightCircleOuterRadius { get; set; }

		// @property (nonatomic) CGFloat highlightCircleStrokeWidth;
		[Export("highlightCircleStrokeWidth")]
		nfloat HighlightCircleStrokeWidth { get; set; }
	}

	// @interface RadarChartRenderer : LineRadarChartRenderer
	[BaseType(typeof(LineRadarChartRenderer), Name = "_TtC6Charts18RadarChartRenderer")]
	interface RadarChartRenderer
	{
		// @property (nonatomic, weak) RadarChartView * _Nullable chart;
		[NullAllowed, Export("chart", ArgumentSemantic.Weak)]
		RadarChartView Chart { get; set; }

		// -(instancetype _Nonnull)initWithChart:(RadarChartView * _Nonnull)chart animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithChart:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(RadarChartView chart, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawWebWithContext:(CGContextRef _Nonnull)context;
		[Export("drawWebWithContext:")]
		unsafe void DrawWebWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface RadarChartView : PieRadarChartViewBase
	[BaseType(typeof(PieRadarChartViewBase), Name = "_TtC6Charts14RadarChartView")]
	interface RadarChartView
	{
		// @property (nonatomic) CGFloat webLineWidth;
		[Export("webLineWidth")]
		nfloat WebLineWidth { get; set; }

		// @property (nonatomic) CGFloat innerWebLineWidth;
		[Export("innerWebLineWidth")]
		nfloat InnerWebLineWidth { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull webColor;
		[Export("webColor", ArgumentSemantic.Strong)]
		UIColor WebColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull innerWebColor;
		[Export("innerWebColor", ArgumentSemantic.Strong)]
		UIColor InnerWebColor { get; set; }

		// @property (nonatomic) CGFloat webAlpha;
		[Export("webAlpha")]
		nfloat WebAlpha { get; set; }

		// @property (nonatomic) BOOL drawWeb;
		[Export("drawWeb")]
		bool DrawWeb { get; set; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);

		// -(void)notifyDataSetChanged;
		[Export("notifyDataSetChanged")]
		void NotifyDataSetChanged();

		// -(void)drawRect:(CGRect)rect;
		[Export("drawRect:")]
		void DrawRect(CGRect rect);

		// @property (readonly, nonatomic) CGFloat factor;
		[Export("factor")]
		nfloat Factor { get; }

		// @property (readonly, nonatomic) CGFloat sliceAngle;
		[Export("sliceAngle")]
		nfloat SliceAngle { get; }

		// -(NSInteger)indexForAngle:(CGFloat)angle __attribute__((warn_unused_result));
		[Export("indexForAngle:")]
		nint IndexForAngle(nfloat angle);

		// @property (readonly, nonatomic, strong) ChartYAxis * _Nonnull yAxis;
		[Export("yAxis", ArgumentSemantic.Strong)]
		ChartYAxis YAxis { get; }

		// @property (nonatomic) NSInteger skipWebLineCount;
		[Export("skipWebLineCount")]
		nint SkipWebLineCount { get; set; }

		// @property (readonly, nonatomic) CGFloat radius;
		[Export("radius")]
		nfloat Radius { get; }

		// @property (readonly, nonatomic) double chartYMax;
		[Export("chartYMax")]
		double ChartYMax { get; }

		// @property (readonly, nonatomic) double chartYMin;
		[Export("chartYMin")]
		double ChartYMin { get; }

		// @property (readonly, nonatomic) double yRange;
		[Export("yRange")]
		double YRange { get; }
	}

	// @interface RadarChartHighlighter : PieRadarChartHighlighter
	[BaseType(typeof(PieRadarChartHighlighter))]
	interface RadarChartHighlighter
	{
		// -(ChartHighlight * _Nullable)closestHighlightWithIndex:(NSInteger)index x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("closestHighlightWithIndex:x:y:")]
		[return: NullAllowed]
		ChartHighlight ClosestHighlightWithIndex(nint index, nfloat x, nfloat y);

		// -(instancetype _Nonnull)initWithChart:(id<ChartDataProvider> _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithChart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartDataProvider chart);
	}

	// @interface ChartRange : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ChartRange
	{
		// @property (nonatomic) double from;
		[Export("from")]
		double From { get; set; }

		// @property (nonatomic) double to;
		[Export("to")]
		double To { get; set; }

		// -(instancetype _Nonnull)initFrom:(double)from to:(double)to __attribute__((objc_designated_initializer));
		[Export("initFrom:to:")]
		[DesignatedInitializer]
		IntPtr Constructor(double from, double to);

		// -(BOOL)contains:(double)value __attribute__((warn_unused_result));
		[Export("contains:")]
		bool Contains(double value);

		// -(BOOL)isLarger:(double)value __attribute__((warn_unused_result));
		[Export("isLarger:")]
		bool IsLarger(double value);

		// -(BOOL)isSmaller:(double)value __attribute__((warn_unused_result));
		[Export("isSmaller:")]
		bool IsSmaller(double value);
	}

	// @interface ScatterChartData : BarLineScatterCandleBubbleChartData
	[BaseType(typeof(BarLineScatterCandleBubbleChartData), Name = "_TtC6Charts16ScatterChartData")]
	interface ScatterChartData
	{
		// -(instancetype _Nonnull)initWithDataSets:(NSArray<id<IChartDataSet>> * _Nullable)dataSets __attribute__((objc_designated_initializer));
		[Export("initWithDataSets:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] IChartDataSet[] dataSets);

		// -(CGFloat)getGreatestShapeSize __attribute__((warn_unused_result));
		[Export("getGreatestShapeSize")]

		nfloat GreatestShapeSize { get; }
	}

	// @interface ScatterChartDataSet : LineScatterCandleRadarChartDataSet <IScatterChartDataSet>
	[BaseType(typeof(LineScatterCandleRadarChartDataSet), Name = "_TtC6Charts19ScatterChartDataSet")]
	interface ScatterChartDataSet : IScatterChartDataSet
	{
		// @property (nonatomic) CGFloat scatterShapeSize;
		[Export("scatterShapeSize")]
		nfloat ScatterShapeSize { get; set; }

		// @property (nonatomic) CGFloat scatterShapeHoleRadius;
		[Export("scatterShapeHoleRadius")]
		nfloat ScatterShapeHoleRadius { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable scatterShapeHoleColor;
		[NullAllowed, Export("scatterShapeHoleColor", ArgumentSemantic.Strong)]
		UIColor ScatterShapeHoleColor { get; set; }

		// -(void)setScatterShape:(enum ScatterShape)shape;
		[Export("setScatterShape:")]
		void SetScatterShape(ScatterShape shape);

		// @property (nonatomic, strong) id<IShapeRenderer> _Nullable shapeRenderer;
		[NullAllowed, Export("shapeRenderer", ArgumentSemantic.Strong)]
		IShapeRenderer ShapeRenderer { get; set; }

		// +(id<IShapeRenderer> _Nonnull)rendererForShape:(enum ScatterShape)shape __attribute__((warn_unused_result));
		[Static]
		[Export("rendererForShape:")]
		IShapeRenderer RendererForShape(ScatterShape shape);

		// -(id _Nonnull)copyWithZone:(struct _NSZone * _Nullable)zone __attribute__((warn_unused_result));
		[Export("copyWithZone:")]
		unsafe NSObject CopyWithZone([NullAllowed] NSZone zone);

		// -(instancetype _Nonnull)initWithEntries:(NSArray<ChartDataEntry *> * _Nullable)entries label:(NSString * _Nullable)label __attribute__((objc_designated_initializer));
		[Export("initWithEntries:label:")]
		[DesignatedInitializer]
		IntPtr Constructor([NullAllowed] ChartDataEntry[] entries, [NullAllowed] string label);
	}

	// @interface ScatterChartRenderer : LineScatterCandleRadarChartRenderer
	[BaseType(typeof(LineScatterCandleRadarChartRenderer), Name = "_TtC6Charts20ScatterChartRenderer")]
	interface ScatterChartRenderer
	{
		// @property (nonatomic, weak) id<ScatterChartDataProvider> _Nullable dataProvider;
		[NullAllowed, Export("dataProvider", ArgumentSemantic.Weak)]
		ScatterChartDataProvider DataProvider { get; set; }

		// -(instancetype _Nonnull)initWithDataProvider:(id<ScatterChartDataProvider> _Nonnull)dataProvider animator:(ChartAnimator * _Nonnull)animator viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithDataProvider:animator:viewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ScatterChartDataProvider dataProvider, ChartAnimator animator, ChartViewPortHandler viewPortHandler);

		// -(void)drawDataWithContext:(CGContextRef _Nonnull)context;
		[Export("drawDataWithContext:")]
		unsafe void DrawDataWithContext(CGContext context);

		// -(void)drawDataSetWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet;
		[Export("drawDataSetWithContext:dataSet:")]
		unsafe void DrawDataSetWithContext(CGContext context, IScatterChartDataSet dataSet);

		// -(void)drawValuesWithContext:(CGContextRef _Nonnull)context;
		[Export("drawValuesWithContext:")]
		unsafe void DrawValuesWithContext(CGContext context);

		// -(void)drawExtrasWithContext:(CGContextRef _Nonnull)context;
		[Export("drawExtrasWithContext:")]
		unsafe void DrawExtrasWithContext(CGContext context);

		// -(void)drawHighlightedWithContext:(CGContextRef _Nonnull)context indices:(NSArray<ChartHighlight *> * _Nonnull)indices;
		[Export("drawHighlightedWithContext:indices:")]
		unsafe void DrawHighlightedWithContext(CGContext context, ChartHighlight[] indices);
	}

	// @interface ScatterChartView : BarLineChartViewBase <ScatterChartDataProvider>
	[BaseType(typeof(BarLineChartViewBase), Name = "_TtC6Charts16ScatterChartView")]
	interface ScatterChartView : ScatterChartDataProvider
	{
		// @property (readonly, nonatomic, strong) ScatterChartData * _Nullable scatterData;
		[NullAllowed, Export("scatterData", ArgumentSemantic.Strong)]
		ScatterChartData ScatterData { get; }

		// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
		[Export("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor(CGRect frame);

		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
		[Export("initWithCoder:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSCoder aDecoder);
	}

	// @interface SquareShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts19SquareShapeRenderer")]
	interface SquareShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface ChartTransformer : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ChartTransformer
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler);

		// -(void)prepareMatrixValuePxWithChartXMin:(double)chartXMin deltaX:(CGFloat)deltaX deltaY:(CGFloat)deltaY chartYMin:(double)chartYMin;
		[Export("prepareMatrixValuePxWithChartXMin:deltaX:deltaY:chartYMin:")]
		void PrepareMatrixValuePxWithChartXMin(double chartXMin, nfloat deltaX, nfloat deltaY, double chartYMin);

		// -(void)prepareMatrixOffsetWithInverted:(BOOL)inverted;
		[Export("prepareMatrixOffsetWithInverted:")]
		void PrepareMatrixOffsetWithInverted(bool inverted);

		// -(CGPoint)pixelForValuesWithX:(double)x y:(double)y __attribute__((warn_unused_result));
		[Export("pixelForValuesWithX:y:")]
		CGPoint PixelForValuesWithX(double x, double y);

		// -(CGPoint)valueForTouchPoint:(CGPoint)point __attribute__((warn_unused_result));
		[Export("valueForTouchPoint:")]
		CGPoint ValueForTouchPoint(CGPoint point);

		// -(CGPoint)valueForTouchPointWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("valueForTouchPointWithX:y:")]
		CGPoint ValueForTouchPointWithX(nfloat x, nfloat y);

		// @property (readonly, nonatomic) CGAffineTransform valueToPixelMatrix;
		[Export("valueToPixelMatrix")]
		CGAffineTransform ValueToPixelMatrix { get; }

		// @property (readonly, nonatomic) CGAffineTransform pixelToValueMatrix;
		[Export("pixelToValueMatrix")]
		CGAffineTransform PixelToValueMatrix { get; }
	}

	// @interface ChartTransformerHorizontalBarChart : ChartTransformer
	[BaseType(typeof(ChartTransformer))]
	interface ChartTransformerHorizontalBarChart
	{
		// -(void)prepareMatrixOffsetWithInverted:(BOOL)inverted;
		[Export("prepareMatrixOffsetWithInverted:")]
		void PrepareMatrixOffsetWithInverted(bool inverted);

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler);
	}

	// @interface TriangleShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts21TriangleShapeRenderer")]
	interface TriangleShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface Charts_Swift_4324 (UIPanGestureRecognizer)
	[Category]
	[BaseType(typeof(UIPanGestureRecognizer))]
	interface UIPanGestureRecognizer_Charts_Swift_4324
	{
		// -(NSInteger)nsuiNumberOfTouches __attribute__((warn_unused_result));
		[Export("nsuiNumberOfTouches")]

		nint NsuiNumberOfTouches { get; }

		// -(CGPoint)nsuiLocationOfTouch:(NSInteger)touch inView:(UIView * _Nullable)inView __attribute__((warn_unused_result));
		[Export("nsuiLocationOfTouch:inView:")]
		CGPoint NsuiLocationOfTouch(nint touch, [NullAllowed] UIView inView);
	}

	// @interface Charts_Swift_4330 (UIScreen)
	[Category]
	[BaseType(typeof(UIScreen))]
	interface UIScreen_Charts_Swift_4330
	{
		// @property (readonly, nonatomic) CGFloat nsuiScale;
		[Export("nsuiScale")]
		nfloat NsuiScale { get; }
	}

	// @interface Charts_Swift_4335 (UIScrollView)
	[Category]
	[BaseType(typeof(UIScrollView))]
	interface UIScrollView_Charts_Swift_4335
	{
		// @property (nonatomic) BOOL nsuiIsScrollEnabled;
		[Export("nsuiIsScrollEnabled")]
		bool NsuiIsScrollEnabled { get; set; }
	}

	// @interface Charts_Swift_4340 (UITapGestureRecognizer)
	[Category]
	[BaseType(typeof(UITapGestureRecognizer))]
	interface UITapGestureRecognizer_Charts_Swift_4340
	{
		// -(NSInteger)nsuiNumberOfTouches __attribute__((warn_unused_result));
		[Export("nsuiNumberOfTouches")]

		nint NsuiNumberOfTouches { get; }

		// @property (nonatomic) NSInteger nsuiNumberOfTapsRequired;
		[Export("nsuiNumberOfTapsRequired")]
		nint NsuiNumberOfTapsRequired { get; set; }
	}

	// @interface Charts_Swift_4346 (UIView)
	[Category]
	[BaseType(typeof(UIView))]
	interface UIView_Charts_Swift_4346
	{
		// @property (readonly, copy, nonatomic) NSArray<UIGestureRecognizer *> * _Nullable nsuiGestureRecognizers;
		[NullAllowed, Export("nsuiGestureRecognizers", ArgumentSemantic.Copy)]
		UIGestureRecognizer[] NsuiGestureRecognizers { get; }
	}

	// @interface ChartViewPortHandler : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ChartViewPortHandler
	{
		// -(instancetype _Nonnull)initWithWidth:(CGFloat)width height:(CGFloat)height __attribute__((objc_designated_initializer));
		[Export("initWithWidth:height:")]
		[DesignatedInitializer]
		IntPtr Constructor(nfloat width, nfloat height);

		// -(void)setChartDimensWithWidth:(CGFloat)width height:(CGFloat)height;
		[Export("setChartDimensWithWidth:height:")]
		void SetChartDimensWithWidth(nfloat width, nfloat height);

		// @property (readonly, nonatomic) BOOL hasChartDimens;
		[Export("hasChartDimens")]
		bool HasChartDimens { get; }

		// -(void)restrainViewPortWithOffsetLeft:(CGFloat)offsetLeft offsetTop:(CGFloat)offsetTop offsetRight:(CGFloat)offsetRight offsetBottom:(CGFloat)offsetBottom;
		[Export("restrainViewPortWithOffsetLeft:offsetTop:offsetRight:offsetBottom:")]
		void RestrainViewPortWithOffsetLeft(nfloat offsetLeft, nfloat offsetTop, nfloat offsetRight, nfloat offsetBottom);

		// @property (readonly, nonatomic) CGFloat offsetLeft;
		[Export("offsetLeft")]
		nfloat OffsetLeft { get; }

		// @property (readonly, nonatomic) CGFloat offsetRight;
		[Export("offsetRight")]
		nfloat OffsetRight { get; }

		// @property (readonly, nonatomic) CGFloat offsetTop;
		[Export("offsetTop")]
		nfloat OffsetTop { get; }

		// @property (readonly, nonatomic) CGFloat offsetBottom;
		[Export("offsetBottom")]
		nfloat OffsetBottom { get; }

		// @property (readonly, nonatomic) CGFloat contentTop;
		[Export("contentTop")]
		nfloat ContentTop { get; }

		// @property (readonly, nonatomic) CGFloat contentLeft;
		[Export("contentLeft")]
		nfloat ContentLeft { get; }

		// @property (readonly, nonatomic) CGFloat contentRight;
		[Export("contentRight")]
		nfloat ContentRight { get; }

		// @property (readonly, nonatomic) CGFloat contentBottom;
		[Export("contentBottom")]
		nfloat ContentBottom { get; }

		// @property (readonly, nonatomic) CGFloat contentWidth;
		[Export("contentWidth")]
		nfloat ContentWidth { get; }

		// @property (readonly, nonatomic) CGFloat contentHeight;
		[Export("contentHeight")]
		nfloat ContentHeight { get; }

		// @property (readonly, nonatomic) CGRect contentRect;
		[Export("contentRect")]
		CGRect ContentRect { get; }

		// @property (readonly, nonatomic) CGPoint contentCenter;
		[Export("contentCenter")]
		CGPoint ContentCenter { get; }

		// @property (readonly, nonatomic) CGFloat chartHeight;
		[Export("chartHeight")]
		nfloat ChartHeight { get; }

		// @property (readonly, nonatomic) CGFloat chartWidth;
		[Export("chartWidth")]
		nfloat ChartWidth { get; }

		// -(CGAffineTransform)zoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY __attribute__((warn_unused_result));
		[Export("zoomWithScaleX:scaleY:")]
		CGAffineTransform ZoomWithScaleX(nfloat scaleX, nfloat scaleY);

		// -(CGAffineTransform)zoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("zoomWithScaleX:scaleY:x:y:")]
		CGAffineTransform ZoomWithScaleX(nfloat scaleX, nfloat scaleY, nfloat x, nfloat y);

		// -(CGAffineTransform)zoomInX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("zoomInX:y:")]
		CGAffineTransform ZoomInX(nfloat x, nfloat y);

		// -(CGAffineTransform)zoomOutWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("zoomOutWithX:y:")]
		CGAffineTransform ZoomOutWithX(nfloat x, nfloat y);

		// -(CGAffineTransform)resetZoom __attribute__((warn_unused_result));
		[Export("resetZoom")]

		CGAffineTransform ResetZoom { get; }

		// -(CGAffineTransform)setZoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY __attribute__((warn_unused_result));
		[Export("setZoomWithScaleX:scaleY:")]
		CGAffineTransform SetZoomWithScaleX(nfloat scaleX, nfloat scaleY);

		// -(CGAffineTransform)setZoomWithScaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY x:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("setZoomWithScaleX:scaleY:x:y:")]
		CGAffineTransform SetZoomWithScaleX(nfloat scaleX, nfloat scaleY, nfloat x, nfloat y);

		// -(CGAffineTransform)fitScreen __attribute__((warn_unused_result));
		[Export("fitScreen")]

		CGAffineTransform FitScreen { get; }

		// -(CGAffineTransform)translateWithPt:(CGPoint)pt __attribute__((warn_unused_result));
		[Export("translateWithPt:")]
		CGAffineTransform TranslateWithPt(CGPoint pt);

		// -(void)centerViewPortWithPt:(CGPoint)pt chart:(ChartViewBase * _Nonnull)chart;
		[Export("centerViewPortWithPt:chart:")]
		void CenterViewPortWithPt(CGPoint pt, ChartViewBase chart);

		// -(CGAffineTransform)refreshWithNewMatrix:(CGAffineTransform)newMatrix chart:(ChartViewBase * _Nonnull)chart invalidate:(BOOL)invalidate;
		[Export("refreshWithNewMatrix:chart:invalidate:")]
		CGAffineTransform RefreshWithNewMatrix(CGAffineTransform newMatrix, ChartViewBase chart, bool invalidate);

		// -(void)setMinimumScaleX:(CGFloat)xScale;
		[Export("setMinimumScaleX:")]
		void SetMinimumScaleX(nfloat xScale);

		// -(void)setMaximumScaleX:(CGFloat)xScale;
		[Export("setMaximumScaleX:")]
		void SetMaximumScaleX(nfloat xScale);

		// -(void)setMinMaxScaleXWithMinScaleX:(CGFloat)minScaleX maxScaleX:(CGFloat)maxScaleX;
		[Export("setMinMaxScaleXWithMinScaleX:maxScaleX:")]
		void SetMinMaxScaleXWithMinScaleX(nfloat minScaleX, nfloat maxScaleX);

		// -(void)setMinimumScaleY:(CGFloat)yScale;
		[Export("setMinimumScaleY:")]
		void SetMinimumScaleY(nfloat yScale);

		// -(void)setMaximumScaleY:(CGFloat)yScale;
		[Export("setMaximumScaleY:")]
		void SetMaximumScaleY(nfloat yScale);

		// -(void)setMinMaxScaleYWithMinScaleY:(CGFloat)minScaleY maxScaleY:(CGFloat)maxScaleY;
		[Export("setMinMaxScaleYWithMinScaleY:maxScaleY:")]
		void SetMinMaxScaleYWithMinScaleY(nfloat minScaleY, nfloat maxScaleY);

		// @property (readonly, nonatomic) CGAffineTransform touchMatrix;
		[Export("touchMatrix")]
		CGAffineTransform TouchMatrix { get; }

		// -(BOOL)isInBoundsX:(CGFloat)x __attribute__((warn_unused_result));
		[Export("isInBoundsX:")]
		bool IsInBoundsX(nfloat x);

		// -(BOOL)isInBoundsY:(CGFloat)y __attribute__((warn_unused_result));
		[Export("isInBoundsY:")]
		bool IsInBoundsY(nfloat y);

		// -(BOOL)isInBoundsWithPoint:(CGPoint)point __attribute__((warn_unused_result));
		[Export("isInBoundsWithPoint:")]
		bool IsInBoundsWithPoint(CGPoint point);

		// -(BOOL)isInBoundsWithX:(CGFloat)x y:(CGFloat)y __attribute__((warn_unused_result));
		[Export("isInBoundsWithX:y:")]
		bool IsInBoundsWithX(nfloat x, nfloat y);

		// -(BOOL)isInBoundsLeft:(CGFloat)x __attribute__((warn_unused_result));
		[Export("isInBoundsLeft:")]
		bool IsInBoundsLeft(nfloat x);

		// -(BOOL)isInBoundsRight:(CGFloat)x __attribute__((warn_unused_result));
		[Export("isInBoundsRight:")]
		bool IsInBoundsRight(nfloat x);

		// -(BOOL)isInBoundsTop:(CGFloat)y __attribute__((warn_unused_result));
		[Export("isInBoundsTop:")]
		bool IsInBoundsTop(nfloat y);

		// -(BOOL)isInBoundsBottom:(CGFloat)y __attribute__((warn_unused_result));
		[Export("isInBoundsBottom:")]
		bool IsInBoundsBottom(nfloat y);

		// -(BOOL)isIntersectingLineFrom:(CGPoint)startPoint to:(CGPoint)endPoint __attribute__((warn_unused_result));
		[Export("isIntersectingLineFrom:to:")]
		bool IsIntersectingLineFrom(CGPoint startPoint, CGPoint endPoint);

		// @property (readonly, nonatomic) CGFloat scaleX;
		[Export("scaleX")]
		nfloat ScaleX { get; }

		// @property (readonly, nonatomic) CGFloat scaleY;
		[Export("scaleY")]
		nfloat ScaleY { get; }

		// @property (readonly, nonatomic) CGFloat minScaleX;
		[Export("minScaleX")]
		nfloat MinScaleX { get; }

		// @property (readonly, nonatomic) CGFloat minScaleY;
		[Export("minScaleY")]
		nfloat MinScaleY { get; }

		// @property (readonly, nonatomic) CGFloat maxScaleX;
		[Export("maxScaleX")]
		nfloat MaxScaleX { get; }

		// @property (readonly, nonatomic) CGFloat maxScaleY;
		[Export("maxScaleY")]
		nfloat MaxScaleY { get; }

		// @property (readonly, nonatomic) CGFloat transX;
		[Export("transX")]
		nfloat TransX { get; }

		// @property (readonly, nonatomic) CGFloat transY;
		[Export("transY")]
		nfloat TransY { get; }

		// @property (readonly, nonatomic) BOOL isFullyZoomedOut;
		[Export("isFullyZoomedOut")]
		bool IsFullyZoomedOut { get; }

		// @property (readonly, nonatomic) BOOL isFullyZoomedOutY;
		[Export("isFullyZoomedOutY")]
		bool IsFullyZoomedOutY { get; }

		// @property (readonly, nonatomic) BOOL isFullyZoomedOutX;
		[Export("isFullyZoomedOutX")]
		bool IsFullyZoomedOutX { get; }

		// -(void)setDragOffsetX:(CGFloat)offset;
		[Export("setDragOffsetX:")]
		void SetDragOffsetX(nfloat offset);

		// -(void)setDragOffsetY:(CGFloat)offset;
		[Export("setDragOffsetY:")]
		void SetDragOffsetY(nfloat offset);

		// @property (readonly, nonatomic) BOOL hasNoDragOffset;
		[Export("hasNoDragOffset")]
		bool HasNoDragOffset { get; }

		// @property (readonly, nonatomic) BOOL canZoomOutMoreX;
		[Export("canZoomOutMoreX")]
		bool CanZoomOutMoreX { get; }

		// @property (readonly, nonatomic) BOOL canZoomInMoreX;
		[Export("canZoomInMoreX")]
		bool CanZoomInMoreX { get; }

		// @property (readonly, nonatomic) BOOL canZoomOutMoreY;
		[Export("canZoomOutMoreY")]
		bool CanZoomOutMoreY { get; }

		// @property (readonly, nonatomic) BOOL canZoomInMoreY;
		[Export("canZoomInMoreY")]
		bool CanZoomInMoreY { get; }
	}

	// @interface ChartXAxis : ChartAxisBase
	[BaseType(typeof(ChartAxisBase))]
	interface ChartXAxis
	{
		// @property (nonatomic) CGFloat labelWidth;
		[Export("labelWidth")]
		nfloat LabelWidth { get; set; }

		// @property (nonatomic) CGFloat labelHeight;
		[Export("labelHeight")]
		nfloat LabelHeight { get; set; }

		// @property (nonatomic) CGFloat labelRotatedWidth;
		[Export("labelRotatedWidth")]
		nfloat LabelRotatedWidth { get; set; }

		// @property (nonatomic) CGFloat labelRotatedHeight;
		[Export("labelRotatedHeight")]
		nfloat LabelRotatedHeight { get; set; }

		// @property (nonatomic) CGFloat labelRotationAngle;
		[Export("labelRotationAngle")]
		nfloat LabelRotationAngle { get; set; }

		// @property (nonatomic) BOOL avoidFirstLastClippingEnabled;
		[Export("avoidFirstLastClippingEnabled")]
		bool AvoidFirstLastClippingEnabled { get; set; }

		// @property (nonatomic) enum XAxisLabelPosition labelPosition;
		[Export("labelPosition", ArgumentSemantic.Assign)]
		XAxisLabelPosition LabelPosition { get; set; }

		// @property (nonatomic) BOOL wordWrapEnabled;
		[Export("wordWrapEnabled")]
		bool WordWrapEnabled { get; set; }

		// @property (readonly, nonatomic) BOOL isWordWrapEnabled;
		[Export("isWordWrapEnabled")]
		bool IsWordWrapEnabled { get; }

		// @property (nonatomic) CGFloat wordWrapWidthPercent;
		[Export("wordWrapWidthPercent")]
		nfloat WordWrapWidthPercent { get; set; }

		// @property (readonly, nonatomic) BOOL isAvoidFirstLastClippingEnabled;
		[Export("isAvoidFirstLastClippingEnabled")]
		bool IsAvoidFirstLastClippingEnabled { get; }
	}

	// @interface ChartXAxisRenderer : ChartAxisRendererBase
	[BaseType(typeof(ChartAxisRendererBase))]
	interface ChartXAxisRenderer
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xAxis:(ChartXAxis * _Nullable)xAxis transformer:(ChartTransformer * _Nullable)transformer __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xAxis:transformer:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartXAxis xAxis, [NullAllowed] ChartTransformer transformer);

		// -(void)computeAxisWithMin:(double)min max:(double)max inverted:(BOOL)inverted;
		[Export("computeAxisWithMin:max:inverted:")]
		void ComputeAxisWithMin(double min, double max, bool inverted);

		// -(void)computeAxisValuesWithMin:(double)min max:(double)max;
		[Export("computeAxisValuesWithMin:max:")]
		void ComputeAxisValuesWithMin(double min, double max);

		// -(void)computeSize;
		[Export("computeSize")]
		void ComputeSize();

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)renderAxisLineWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLineWithContext:")]
		unsafe void RenderAxisLineWithContext(CGContext context);

		// -(void)drawLabelsWithContext:(CGContextRef _Nonnull)context pos:(CGFloat)pos anchor:(CGPoint)anchor;
		[Export("drawLabelsWithContext:pos:anchor:")]
		unsafe void DrawLabelsWithContext(CGContext context, nfloat pos, CGPoint anchor);

		// -(void)drawLabelWithContext:(CGContextRef _Nonnull)context formattedLabel:(NSString * _Nonnull)formattedLabel x:(CGFloat)x y:(CGFloat)y attributes:(NSDictionary<NSAttributedStringKey,id> * _Nonnull)attributes constrainedToSize:(CGSize)constrainedToSize anchor:(CGPoint)anchor angleRadians:(CGFloat)angleRadians;
		[Export("drawLabelWithContext:formattedLabel:x:y:attributes:constrainedToSize:anchor:angleRadians:")]
		unsafe void DrawLabelWithContext(CGContext context, string formattedLabel, nfloat x, nfloat y, NSDictionary<NSString, NSObject> attributes, CGSize constrainedToSize, CGPoint anchor, nfloat angleRadians);

		// -(void)renderGridLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderGridLinesWithContext:")]
		unsafe void RenderGridLinesWithContext(CGContext context);

		// @property (readonly, nonatomic) CGRect gridClippingRect;
		[Export("gridClippingRect")]
		CGRect GridClippingRect { get; }

		// -(void)drawGridLineWithContext:(CGContextRef _Nonnull)context x:(CGFloat)x y:(CGFloat)y;
		[Export("drawGridLineWithContext:x:y:")]
		unsafe void DrawGridLineWithContext(CGContext context, nfloat x, nfloat y);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);

		// -(void)renderLimitLineLineWithContext:(CGContextRef _Nonnull)context limitLine:(ChartLimitLine * _Nonnull)limitLine position:(CGPoint)position;
		[Export("renderLimitLineLineWithContext:limitLine:position:")]
		unsafe void RenderLimitLineLineWithContext(CGContext context, ChartLimitLine limitLine, CGPoint position);

		// -(void)renderLimitLineLabelWithContext:(CGContextRef _Nonnull)context limitLine:(ChartLimitLine * _Nonnull)limitLine position:(CGPoint)position yOffset:(CGFloat)yOffset;
		[Export("renderLimitLineLabelWithContext:limitLine:position:yOffset:")]
		unsafe void RenderLimitLineLabelWithContext(CGContext context, ChartLimitLine limitLine, CGPoint position, nfloat yOffset);
	}

	// @interface XAxisRendererHorizontalBarChart : ChartXAxisRenderer
	[BaseType(typeof(ChartXAxisRenderer), Name = "_TtC6Charts31XAxisRendererHorizontalBarChart")]
	interface XAxisRendererHorizontalBarChart
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xAxis:(ChartXAxis * _Nullable)xAxis transformer:(ChartTransformer * _Nullable)transformer chart:(BarChartView * _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xAxis:transformer:chart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartXAxis xAxis, [NullAllowed] ChartTransformer transformer, BarChartView chart);

		// -(void)computeAxisWithMin:(double)min max:(double)max inverted:(BOOL)inverted;
		[Export("computeAxisWithMin:max:inverted:")]
		void ComputeAxisWithMin(double min, double max, bool inverted);

		// -(void)computeSize;
		[Export("computeSize")]
		void ComputeSize();

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)drawLabelsWithContext:(CGContextRef _Nonnull)context pos:(CGFloat)pos anchor:(CGPoint)anchor;
		[Export("drawLabelsWithContext:pos:anchor:")]
		unsafe void DrawLabelsWithContext(CGContext context, nfloat pos, CGPoint anchor);

		// -(void)drawLabelWithContext:(CGContextRef _Nonnull)context formattedLabel:(NSString * _Nonnull)formattedLabel x:(CGFloat)x y:(CGFloat)y attributes:(NSDictionary<NSAttributedStringKey,id> * _Nonnull)attributes anchor:(CGPoint)anchor angleRadians:(CGFloat)angleRadians;
		[Export("drawLabelWithContext:formattedLabel:x:y:attributes:anchor:angleRadians:")]
		unsafe void DrawLabelWithContext(CGContext context, string formattedLabel, nfloat x, nfloat y, NSDictionary<NSString, NSObject> attributes, CGPoint anchor, nfloat angleRadians);

		// @property (readonly, nonatomic) CGRect gridClippingRect;
		[Export("gridClippingRect")]
		CGRect GridClippingRect { get; }

		// -(void)drawGridLineWithContext:(CGContextRef _Nonnull)context x:(CGFloat)x y:(CGFloat)y;
		[Export("drawGridLineWithContext:x:y:")]
		unsafe void DrawGridLineWithContext(CGContext context, nfloat x, nfloat y);

		// -(void)renderAxisLineWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLineWithContext:")]
		unsafe void RenderAxisLineWithContext(CGContext context);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);
	}

	// @interface XAxisRendererRadarChart : ChartXAxisRenderer
	[BaseType(typeof(ChartXAxisRenderer), Name = "_TtC6Charts23XAxisRendererRadarChart")]
	interface XAxisRendererRadarChart
	{
		// @property (nonatomic, weak) RadarChartView * _Nullable chart;
		[NullAllowed, Export("chart", ArgumentSemantic.Weak)]
		RadarChartView Chart { get; set; }

		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler xAxis:(ChartXAxis * _Nullable)xAxis chart:(RadarChartView * _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:xAxis:chart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartXAxis xAxis, RadarChartView chart);

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)drawLabelWithContext:(CGContextRef _Nonnull)context formattedLabel:(NSString * _Nonnull)formattedLabel x:(CGFloat)x y:(CGFloat)y attributes:(NSDictionary<NSAttributedStringKey,id> * _Nonnull)attributes anchor:(CGPoint)anchor angleRadians:(CGFloat)angleRadians;
		[Export("drawLabelWithContext:formattedLabel:x:y:attributes:anchor:angleRadians:")]
		unsafe void DrawLabelWithContext(CGContext context, string formattedLabel, nfloat x, nfloat y, NSDictionary<NSString, NSObject> attributes, CGPoint anchor, nfloat angleRadians);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);
	}

	// @interface XShapeRenderer : NSObject <IShapeRenderer>
	[BaseType(typeof(NSObject), Name = "_TtC6Charts14XShapeRenderer")]
	interface XShapeRenderer : IShapeRenderer
	{
		// -(void)renderShapeWithContext:(CGContextRef _Nonnull)context dataSet:(id<IScatterChartDataSet> _Nonnull)dataSet viewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler point:(CGPoint)point color:(UIColor * _Nonnull)color;
		[Export("renderShapeWithContext:dataSet:viewPortHandler:point:color:")]
		unsafe void RenderShapeWithContext(CGContext context, IScatterChartDataSet dataSet, ChartViewPortHandler viewPortHandler, CGPoint point, UIColor color);
	}

	// @interface ChartYAxis : ChartAxisBase
	[BaseType(typeof(ChartAxisBase))]
	interface ChartYAxis
	{
		// @property (nonatomic) BOOL drawBottomYLabelEntryEnabled;
		[Export("drawBottomYLabelEntryEnabled")]
		bool DrawBottomYLabelEntryEnabled { get; set; }

		// @property (nonatomic) BOOL drawTopYLabelEntryEnabled;
		[Export("drawTopYLabelEntryEnabled")]
		bool DrawTopYLabelEntryEnabled { get; set; }

		// @property (nonatomic) BOOL inverted;
		[Export("inverted")]
		bool Inverted { get; set; }

		// @property (nonatomic) BOOL drawZeroLineEnabled;
		[Export("drawZeroLineEnabled")]
		bool DrawZeroLineEnabled { get; set; }

		// @property (nonatomic, strong) UIColor * _Nullable zeroLineColor;
		[NullAllowed, Export("zeroLineColor", ArgumentSemantic.Strong)]
		UIColor ZeroLineColor { get; set; }

		// @property (nonatomic) CGFloat zeroLineWidth;
		[Export("zeroLineWidth")]
		nfloat ZeroLineWidth { get; set; }

		// @property (nonatomic) CGFloat zeroLineDashPhase;
		[Export("zeroLineDashPhase")]
		nfloat ZeroLineDashPhase { get; set; }

		// @property (copy, nonatomic) NSArray<NSNumber *> * _Nullable zeroLineDashLengths;
		[NullAllowed, Export("zeroLineDashLengths", ArgumentSemantic.Copy)]
		NSNumber[] ZeroLineDashLengths { get; set; }

		// @property (nonatomic) CGFloat spaceTop;
		[Export("spaceTop")]
		nfloat SpaceTop { get; set; }

		// @property (nonatomic) CGFloat spaceBottom;
		[Export("spaceBottom")]
		nfloat SpaceBottom { get; set; }

		// @property (nonatomic) enum YAxisLabelPosition labelPosition;
		[Export("labelPosition", ArgumentSemantic.Assign)]
		YAxisLabelPosition LabelPosition { get; set; }

		// @property (nonatomic) NSTextAlignment labelAlignment;
		//[Export ("labelAlignment", ArgumentSemantic.Assign)]
		//NSTextAlignment LabelAlignment { get; set; }

		// @property (nonatomic) CGFloat labelXOffset;
		[Export("labelXOffset")]
		nfloat LabelXOffset { get; set; }

		// @property (nonatomic) CGFloat minWidth;
		[Export("minWidth")]
		nfloat MinWidth { get; set; }

		// @property (nonatomic) CGFloat maxWidth;
		[Export("maxWidth")]
		nfloat MaxWidth { get; set; }

		// -(instancetype _Nonnull)initWithPosition:(enum AxisDependency)position __attribute__((objc_designated_initializer));
		[Export("initWithPosition:")]
		[DesignatedInitializer]
		IntPtr Constructor(AxisDependency position);

		// @property (readonly, nonatomic) enum AxisDependency axisDependency;
		[Export("axisDependency")]
		AxisDependency AxisDependency { get; }

		// -(CGSize)requiredSize __attribute__((warn_unused_result));
		[Export("requiredSize")]

		CGSize RequiredSize { get; }

		// -(CGFloat)getRequiredHeightSpace __attribute__((warn_unused_result));
		[Export("getRequiredHeightSpace")]

		nfloat RequiredHeightSpace { get; }

		// @property (readonly, nonatomic) BOOL needsOffset;
		[Export("needsOffset")]
		bool NeedsOffset { get; }

		// @property (readonly, nonatomic) BOOL isInverted;
		[Export("isInverted")]
		bool IsInverted { get; }

		// -(void)calculateWithMin:(double)dataMin max:(double)dataMax;
		[Export("calculateWithMin:max:")]
		void CalculateWithMin(double dataMin, double dataMax);

		// @property (readonly, nonatomic) BOOL isDrawBottomYLabelEntryEnabled;
		[Export("isDrawBottomYLabelEntryEnabled")]
		bool IsDrawBottomYLabelEntryEnabled { get; }

		// @property (readonly, nonatomic) BOOL isDrawTopYLabelEntryEnabled;
		[Export("isDrawTopYLabelEntryEnabled")]
		bool IsDrawTopYLabelEntryEnabled { get; }
	}

	// @interface ChartYAxisRenderer : ChartAxisRendererBase
	[BaseType(typeof(ChartAxisRendererBase))]
	interface ChartYAxisRenderer
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler yAxis:(ChartYAxis * _Nullable)yAxis transformer:(ChartTransformer * _Nullable)transformer __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:yAxis:transformer:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartYAxis yAxis, [NullAllowed] ChartTransformer transformer);

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)renderAxisLineWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLineWithContext:")]
		unsafe void RenderAxisLineWithContext(CGContext context);

		// -(void)renderGridLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderGridLinesWithContext:")]
		unsafe void RenderGridLinesWithContext(CGContext context);

		// @property (readonly, nonatomic) CGRect gridClippingRect;
		[Export("gridClippingRect")]
		CGRect GridClippingRect { get; }

		// -(void)drawGridLineWithContext:(CGContextRef _Nonnull)context position:(CGPoint)position;
		[Export("drawGridLineWithContext:position:")]
		unsafe void DrawGridLineWithContext(CGContext context, CGPoint position);

		// -(NSArray<NSValue *> * _Nonnull)transformedPositions __attribute__((warn_unused_result));
		[Export("transformedPositions")]

		NSValue[] TransformedPositions { get; }

		// -(void)drawZeroLineWithContext:(CGContextRef _Nonnull)context;
		[Export("drawZeroLineWithContext:")]
		unsafe void DrawZeroLineWithContext(CGContext context);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);
	}

	// @interface YAxisRendererHorizontalBarChart : ChartYAxisRenderer
	[BaseType(typeof(ChartYAxisRenderer), Name = "_TtC6Charts31YAxisRendererHorizontalBarChart")]
	interface YAxisRendererHorizontalBarChart
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler yAxis:(ChartYAxis * _Nullable)yAxis transformer:(ChartTransformer * _Nullable)transformer __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:yAxis:transformer:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartYAxis yAxis, [NullAllowed] ChartTransformer transformer);

		// -(void)computeAxisWithMin:(double)min max:(double)max inverted:(BOOL)inverted;
		[Export("computeAxisWithMin:max:inverted:")]
		void ComputeAxisWithMin(double min, double max, bool inverted);

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)renderAxisLineWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLineWithContext:")]
		unsafe void RenderAxisLineWithContext(CGContext context);

		// -(void)drawYLabelsWithContext:(CGContextRef _Nonnull)context fixedPosition:(CGFloat)fixedPosition positions:(NSArray<NSValue *> * _Nonnull)positions offset:(CGFloat)offset;
		[Export("drawYLabelsWithContext:fixedPosition:positions:offset:")]
		unsafe void DrawYLabelsWithContext(CGContext context, nfloat fixedPosition, NSValue[] positions, nfloat offset);

		// @property (readonly, nonatomic) CGRect gridClippingRect;
		[Export("gridClippingRect")]
		CGRect GridClippingRect { get; }

		// -(void)drawGridLineWithContext:(CGContextRef _Nonnull)context position:(CGPoint)position;
		[Export("drawGridLineWithContext:position:")]
		unsafe void DrawGridLineWithContext(CGContext context, CGPoint position);

		// -(NSArray<NSValue *> * _Nonnull)transformedPositions __attribute__((warn_unused_result));
		[Export("transformedPositions")]

		NSValue[] TransformedPositions { get; }

		// -(void)drawZeroLineWithContext:(CGContextRef _Nonnull)context;
		[Export("drawZeroLineWithContext:")]
		unsafe void DrawZeroLineWithContext(CGContext context);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);
	}

	// @interface YAxisRendererRadarChart : ChartYAxisRenderer
	[BaseType(typeof(ChartYAxisRenderer), Name = "_TtC6Charts23YAxisRendererRadarChart")]
	interface YAxisRendererRadarChart
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler yAxis:(ChartYAxis * _Nullable)yAxis chart:(RadarChartView * _Nonnull)chart __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:yAxis:chart:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, [NullAllowed] ChartYAxis yAxis, RadarChartView chart);

		// -(void)computeAxisValuesWithMin:(double)yMin max:(double)yMax;
		[Export("computeAxisValuesWithMin:max:")]
		void ComputeAxisValuesWithMin(double yMin, double yMax);

		// -(void)renderAxisLabelsWithContext:(CGContextRef _Nonnull)context;
		[Export("renderAxisLabelsWithContext:")]
		unsafe void RenderAxisLabelsWithContext(CGContext context);

		// -(void)renderLimitLinesWithContext:(CGContextRef _Nonnull)context;
		[Export("renderLimitLinesWithContext:")]
		unsafe void RenderLimitLinesWithContext(CGContext context);
	}

	// @interface ZoomChartViewJob : ChartViewPortJob
	[BaseType(typeof(ChartViewPortJob))]
	interface ZoomChartViewJob
	{
		// -(instancetype _Nonnull)initWithViewPortHandler:(ChartViewPortHandler * _Nonnull)viewPortHandler scaleX:(CGFloat)scaleX scaleY:(CGFloat)scaleY xValue:(double)xValue yValue:(double)yValue transformer:(ChartTransformer * _Nonnull)transformer axis:(enum AxisDependency)axis view:(ChartViewBase * _Nonnull)view __attribute__((objc_designated_initializer));
		[Export("initWithViewPortHandler:scaleX:scaleY:xValue:yValue:transformer:axis:view:")]
		[DesignatedInitializer]
		IntPtr Constructor(ChartViewPortHandler viewPortHandler, nfloat scaleX, nfloat scaleY, double xValue, double yValue, ChartTransformer transformer, AxisDependency axis, ChartViewBase view);

		// -(void)doJob;
		[Export("doJob")]
		void DoJob();
	}
}
