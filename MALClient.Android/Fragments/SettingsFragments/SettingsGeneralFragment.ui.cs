using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MALClient.Android.Resources;

namespace MALClient.Android.Fragments.SettingsFragments
{
    public partial class SettingsGeneralFragment
    {
        #region Views

        private RadioButton _settingsPageGeneralRadioAnimeList;
        private RadioButton _settingsPageGeneralRadioMangaList;
        private RadioGroup _settingsPageGeneralStartPageRadioGroup;
        private RadioButton _settingsPageGeneralRadioDarkTheme;
        private RadioButton _settingsPageGeneralRadioLightTheme;
        private RadioGroup _settingsPageGeneralThemeRadioGroup;
        private ImageButton _settingsPageGeneralColorOrange;
        private ImageButton _settingsPageGeneralColorPurple;
        private ImageButton _settingsPageGeneralColorBlue;
        private ImageButton _settingsPageGeneralColorLime;
        private ImageButton _settingsPageGeneralColorPink;
        private Switch _settingsPageGeneralAmoledSwitch;
        private Button _settingsPageGeneralThemeChangeApply;
        private Switch _settingsPageGeneralEnableSwipeSwitch;
        private Switch _settingsPageGeneralPullHigherSwitch;
        private Switch _settingsPageGeneralSeasonSwitch;
        private Switch _settingsPageGeneralAutoSortSwitch;
        private Switch _settingsPageGeneralVolsImportantSwitch;
        private Switch _settingsPageGeneralHideHamburgerMangaSwitch;
        private Switch _settingsPageGeneralPreferEnglishTitleSwitch;
        private Switch _settingsPageGeneralSmallerGridItems;
        private Switch _settingsPageGeneralReverseSwipeOrder;
        private Switch _settingsPageGeneralDisplayScoreDialog;
        private RadioButton _settingsPageGeneralAnimeSortTitleRadioBtn;
        private RadioButton _settingsPageGeneralAnimeScoreTitleRadioBtn;
        private RadioButton _settingsPageGeneralAnimeWatchedTitleRadioBtn;
        private RadioButton _settingsPageGeneralAnimeSoonAiringTitleRadioBtn;
        private RadioButton _settingsPageGeneralAnimeLastWatchTitleRadioBtn;
        private RadioButton _settingsPageGeneralAnimeSortNoneRadioBtn;
        private RadioGroup _settingsPageGeneralAnimeSortRadioGroup;
        private Switch _settingsPageGeneralAnimeSortDescendingSwitch;
        private RadioButton _settingsPageGeneralMangaSortTitleRadioBtn;
        private RadioButton _settingsPageGeneralMangaSortScoreRadioBtn;
        private RadioButton _settingsPageGeneralMangaSortReadRadioBtn;
        private RadioButton _settingsPageGeneralMangaSortNoneRadioBtn;
        private RadioGroup _settingsPageGeneralMangaSortRadioGroup;
        private Switch _settingsPageGeneralMangaSortDescendingSwitch;
        private Spinner _settingsPageGeneralWatchingViewModeSpinner;
        private Spinner _settingsPageGeneralCompletedViewModeSpinner;
        private Spinner _settingsPageGeneralOnHoldViewModeSpinner;
        private Spinner _settingsPageGeneralDroppedViewModeSpinner;
        private Spinner _settingsPageGeneralPtwViewModeSpinner;
        private Spinner _settingsPageGeneralAllViewModeSpinner;
        private Spinner _settingsPageGeneralAnimeFilterSpinner;
        private Spinner _settingsPageGeneralMangaFilerSpinner;
        private Spinner _settingsPageGeneralDefaultAddedStatusSpinner;
        private CheckBox _settingsPageGeneralStartDateWhenAddCheckBox;
        private CheckBox _settingsPageGeneralStartDateWhenWatchCheckBox;
        private CheckBox _settingsPageGeneralEndDateWhenCompleted;
        private CheckBox _settingsPageGeneralEndDateWhenDropCheckBox;
        private CheckBox _settingsPageGeneralAllowDateOverrideCheckBox;
        private TextView _settingsPageGeneralAirDayOffsetTextView;
        private SeekBar _settingsPageGeneralAirDayOffsetSlider;
        private TextView _settingsPageGeneralAiringNotificationOffsetTextView;
        private SeekBar _settingsPageGeneralAiringNotificationOffsetSlider;

        public RadioButton SettingsPageGeneralRadioAnimeList => _settingsPageGeneralRadioAnimeList ?? (_settingsPageGeneralRadioAnimeList = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralRadioAnimeList));

        public RadioButton SettingsPageGeneralRadioMangaList => _settingsPageGeneralRadioMangaList ?? (_settingsPageGeneralRadioMangaList = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralRadioMangaList));

        public RadioGroup SettingsPageGeneralStartPageRadioGroup => _settingsPageGeneralStartPageRadioGroup ?? (_settingsPageGeneralStartPageRadioGroup = FindViewById<RadioGroup>(Resource.Id.SettingsPageGeneralStartPageRadioGroup));

        public RadioButton SettingsPageGeneralRadioDarkTheme => _settingsPageGeneralRadioDarkTheme ?? (_settingsPageGeneralRadioDarkTheme = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralRadioDarkTheme));

        public RadioButton SettingsPageGeneralRadioLightTheme => _settingsPageGeneralRadioLightTheme ?? (_settingsPageGeneralRadioLightTheme = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralRadioLightTheme));

        public RadioGroup SettingsPageGeneralThemeRadioGroup => _settingsPageGeneralThemeRadioGroup ?? (_settingsPageGeneralThemeRadioGroup = FindViewById<RadioGroup>(Resource.Id.SettingsPageGeneralThemeRadioGroup));

        public ImageButton SettingsPageGeneralColorOrange => _settingsPageGeneralColorOrange ?? (_settingsPageGeneralColorOrange = FindViewById<ImageButton>(Resource.Id.SettingsPageGeneralColorOrange));

        public ImageButton SettingsPageGeneralColorPurple => _settingsPageGeneralColorPurple ?? (_settingsPageGeneralColorPurple = FindViewById<ImageButton>(Resource.Id.SettingsPageGeneralColorPurple));

        public ImageButton SettingsPageGeneralColorBlue => _settingsPageGeneralColorBlue ?? (_settingsPageGeneralColorBlue = FindViewById<ImageButton>(Resource.Id.SettingsPageGeneralColorBlue));

        public ImageButton SettingsPageGeneralColorLime => _settingsPageGeneralColorLime ?? (_settingsPageGeneralColorLime = FindViewById<ImageButton>(Resource.Id.SettingsPageGeneralColorLime));

        public ImageButton SettingsPageGeneralColorPink => _settingsPageGeneralColorPink ?? (_settingsPageGeneralColorPink = FindViewById<ImageButton>(Resource.Id.SettingsPageGeneralColorPink));

        public Switch SettingsPageGeneralAmoledSwitch => _settingsPageGeneralAmoledSwitch ?? (_settingsPageGeneralAmoledSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralAmoledSwitch));

        public Button SettingsPageGeneralThemeChangeApply => _settingsPageGeneralThemeChangeApply ?? (_settingsPageGeneralThemeChangeApply = FindViewById<Button>(Resource.Id.SettingsPageGeneralThemeChangeApply));

        public Switch SettingsPageGeneralEnableSwipeSwitch => _settingsPageGeneralEnableSwipeSwitch ?? (_settingsPageGeneralEnableSwipeSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralEnableSwipeSwitch));

        public Switch SettingsPageGeneralPullHigherSwitch => _settingsPageGeneralPullHigherSwitch ?? (_settingsPageGeneralPullHigherSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralPullHigherSwitch));

        public Switch SettingsPageGeneralSeasonSwitch => _settingsPageGeneralSeasonSwitch ?? (_settingsPageGeneralSeasonSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralSeasonSwitch));

        public Switch SettingsPageGeneralAutoSortSwitch => _settingsPageGeneralAutoSortSwitch ?? (_settingsPageGeneralAutoSortSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralAutoSortSwitch));

        public Switch SettingsPageGeneralVolsImportantSwitch => _settingsPageGeneralVolsImportantSwitch ?? (_settingsPageGeneralVolsImportantSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralVolsImportantSwitch));

        public Switch SettingsPageGeneralHideHamburgerMangaSwitch => _settingsPageGeneralHideHamburgerMangaSwitch ?? (_settingsPageGeneralHideHamburgerMangaSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralHideHamburgerMangaSwitch));

        public Switch SettingsPageGeneralPreferEnglishTitleSwitch => _settingsPageGeneralPreferEnglishTitleSwitch ?? (_settingsPageGeneralPreferEnglishTitleSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralPreferEnglishTitleSwitch));

        public Switch SettingsPageGeneralSmallerGridItems => _settingsPageGeneralSmallerGridItems ?? (_settingsPageGeneralSmallerGridItems = FindViewById<Switch>(Resource.Id.SettingsPageGeneralSmallerGridItems));

        public Switch SettingsPageGeneralReverseSwipeOrder => _settingsPageGeneralReverseSwipeOrder ?? (_settingsPageGeneralReverseSwipeOrder = FindViewById<Switch>(Resource.Id.SettingsPageGeneralReverseSwipeOrder));

        public Switch SettingsPageGeneralDisplayScoreDialog => _settingsPageGeneralDisplayScoreDialog ?? (_settingsPageGeneralDisplayScoreDialog = FindViewById<Switch>(Resource.Id.SettingsPageGeneralDisplayScoreDialog));

        public RadioButton SettingsPageGeneralAnimeSortTitleRadioBtn => _settingsPageGeneralAnimeSortTitleRadioBtn ?? (_settingsPageGeneralAnimeSortTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeSortTitleRadioBtn));

        public RadioButton SettingsPageGeneralAnimeScoreTitleRadioBtn => _settingsPageGeneralAnimeScoreTitleRadioBtn ?? (_settingsPageGeneralAnimeScoreTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeScoreTitleRadioBtn));

        public RadioButton SettingsPageGeneralAnimeWatchedTitleRadioBtn => _settingsPageGeneralAnimeWatchedTitleRadioBtn ?? (_settingsPageGeneralAnimeWatchedTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeWatchedTitleRadioBtn));

        public RadioButton SettingsPageGeneralAnimeSoonAiringTitleRadioBtn => _settingsPageGeneralAnimeSoonAiringTitleRadioBtn ?? (_settingsPageGeneralAnimeSoonAiringTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeSoonAiringTitleRadioBtn));

        public RadioButton SettingsPageGeneralAnimeLastWatchTitleRadioBtn => _settingsPageGeneralAnimeLastWatchTitleRadioBtn ?? (_settingsPageGeneralAnimeLastWatchTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeLastWatchTitleRadioBtn));

        public RadioButton SettingsPageGeneralAnimeSortNoneRadioBtn => _settingsPageGeneralAnimeSortNoneRadioBtn ?? (_settingsPageGeneralAnimeSortNoneRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralAnimeSortNoneRadioBtn));

        public RadioGroup SettingsPageGeneralAnimeSortRadioGroup => _settingsPageGeneralAnimeSortRadioGroup ?? (_settingsPageGeneralAnimeSortRadioGroup = FindViewById<RadioGroup>(Resource.Id.SettingsPageGeneralAnimeSortRadioGroup));

        public Switch SettingsPageGeneralAnimeSortDescendingSwitch => _settingsPageGeneralAnimeSortDescendingSwitch ?? (_settingsPageGeneralAnimeSortDescendingSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralAnimeSortDescendingSwitch));

        public RadioButton SettingsPageGeneralMangaSortTitleRadioBtn => _settingsPageGeneralMangaSortTitleRadioBtn ?? (_settingsPageGeneralMangaSortTitleRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralMangaSortTitleRadioBtn));

        public RadioButton SettingsPageGeneralMangaSortScoreRadioBtn => _settingsPageGeneralMangaSortScoreRadioBtn ?? (_settingsPageGeneralMangaSortScoreRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralMangaSortScoreRadioBtn));

        public RadioButton SettingsPageGeneralMangaSortReadRadioBtn => _settingsPageGeneralMangaSortReadRadioBtn ?? (_settingsPageGeneralMangaSortReadRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralMangaSortReadRadioBtn));

        public RadioButton SettingsPageGeneralMangaSortNoneRadioBtn => _settingsPageGeneralMangaSortNoneRadioBtn ?? (_settingsPageGeneralMangaSortNoneRadioBtn = FindViewById<RadioButton>(Resource.Id.SettingsPageGeneralMangaSortNoneRadioBtn));

        public RadioGroup SettingsPageGeneralMangaSortRadioGroup => _settingsPageGeneralMangaSortRadioGroup ?? (_settingsPageGeneralMangaSortRadioGroup = FindViewById<RadioGroup>(Resource.Id.SettingsPageGeneralMangaSortRadioGroup));

        public Switch SettingsPageGeneralMangaSortDescendingSwitch => _settingsPageGeneralMangaSortDescendingSwitch ?? (_settingsPageGeneralMangaSortDescendingSwitch = FindViewById<Switch>(Resource.Id.SettingsPageGeneralMangaSortDescendingSwitch));

        public Spinner SettingsPageGeneralWatchingViewModeSpinner => _settingsPageGeneralWatchingViewModeSpinner ?? (_settingsPageGeneralWatchingViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralWatchingViewModeSpinner));

        public Spinner SettingsPageGeneralCompletedViewModeSpinner => _settingsPageGeneralCompletedViewModeSpinner ?? (_settingsPageGeneralCompletedViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralCompletedViewModeSpinner));

        public Spinner SettingsPageGeneralOnHoldViewModeSpinner => _settingsPageGeneralOnHoldViewModeSpinner ?? (_settingsPageGeneralOnHoldViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralOnHoldViewModeSpinner));

        public Spinner SettingsPageGeneralDroppedViewModeSpinner => _settingsPageGeneralDroppedViewModeSpinner ?? (_settingsPageGeneralDroppedViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralDroppedViewModeSpinner));

        public Spinner SettingsPageGeneralPtwViewModeSpinner => _settingsPageGeneralPtwViewModeSpinner ?? (_settingsPageGeneralPtwViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralPtwViewModeSpinner));

        public Spinner SettingsPageGeneralAllViewModeSpinner => _settingsPageGeneralAllViewModeSpinner ?? (_settingsPageGeneralAllViewModeSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralAllViewModeSpinner));

        public Spinner SettingsPageGeneralAnimeFilterSpinner => _settingsPageGeneralAnimeFilterSpinner ?? (_settingsPageGeneralAnimeFilterSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralAnimeFilterSpinner));

        public Spinner SettingsPageGeneralMangaFilerSpinner => _settingsPageGeneralMangaFilerSpinner ?? (_settingsPageGeneralMangaFilerSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralMangaFilerSpinner));

        public Spinner SettingsPageGeneralDefaultAddedStatusSpinner => _settingsPageGeneralDefaultAddedStatusSpinner ?? (_settingsPageGeneralDefaultAddedStatusSpinner = FindViewById<Spinner>(Resource.Id.SettingsPageGeneralDefaultAddedStatusSpinner));

        public CheckBox SettingsPageGeneralStartDateWhenAddCheckBox => _settingsPageGeneralStartDateWhenAddCheckBox ?? (_settingsPageGeneralStartDateWhenAddCheckBox = FindViewById<CheckBox>(Resource.Id.SettingsPageGeneralStartDateWhenAddCheckBox));

        public CheckBox SettingsPageGeneralStartDateWhenWatchCheckBox => _settingsPageGeneralStartDateWhenWatchCheckBox ?? (_settingsPageGeneralStartDateWhenWatchCheckBox = FindViewById<CheckBox>(Resource.Id.SettingsPageGeneralStartDateWhenWatchCheckBox));

        public CheckBox SettingsPageGeneralEndDateWhenCompleted => _settingsPageGeneralEndDateWhenCompleted ?? (_settingsPageGeneralEndDateWhenCompleted = FindViewById<CheckBox>(Resource.Id.SettingsPageGeneralEndDateWhenCompleted));

        public CheckBox SettingsPageGeneralEndDateWhenDropCheckBox => _settingsPageGeneralEndDateWhenDropCheckBox ?? (_settingsPageGeneralEndDateWhenDropCheckBox = FindViewById<CheckBox>(Resource.Id.SettingsPageGeneralEndDateWhenDropCheckBox));

        public CheckBox SettingsPageGeneralAllowDateOverrideCheckBox => _settingsPageGeneralAllowDateOverrideCheckBox ?? (_settingsPageGeneralAllowDateOverrideCheckBox = FindViewById<CheckBox>(Resource.Id.SettingsPageGeneralAllowDateOverrideCheckBox));

        public TextView SettingsPageGeneralAirDayOffsetTextView => _settingsPageGeneralAirDayOffsetTextView ?? (_settingsPageGeneralAirDayOffsetTextView = FindViewById<TextView>(Resource.Id.SettingsPageGeneralAirDayOffsetTextView));

        public SeekBar SettingsPageGeneralAirDayOffsetSlider => _settingsPageGeneralAirDayOffsetSlider ?? (_settingsPageGeneralAirDayOffsetSlider = FindViewById<SeekBar>(Resource.Id.SettingsPageGeneralAirDayOffsetSlider));

        public TextView SettingsPageGeneralAiringNotificationOffsetTextView => _settingsPageGeneralAiringNotificationOffsetTextView ?? (_settingsPageGeneralAiringNotificationOffsetTextView = FindViewById<TextView>(Resource.Id.SettingsPageGeneralAiringNotificationOffsetTextView));

        public SeekBar SettingsPageGeneralAiringNotificationOffsetSlider => _settingsPageGeneralAiringNotificationOffsetSlider ?? (_settingsPageGeneralAiringNotificationOffsetSlider = FindViewById<SeekBar>(Resource.Id.SettingsPageGeneralAiringNotificationOffsetSlider));

        #endregion
    }
}