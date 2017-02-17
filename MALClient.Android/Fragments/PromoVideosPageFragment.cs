using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Widget;
using FFImageLoading.Views;
using GalaSoft.MvvmLight.Helpers;
using MALClient.Android.BindingConverters;
using MALClient.Android.Resources;
using MALClient.Models.Models.AnimeScrapped;
using MALClient.XShared.ViewModels;
using MALClient.XShared.ViewModels.Details;
using MALClient.XShared.ViewModels.Main;

namespace MALClient.Android.Fragments
{
    public class PromoVideosPageFragment : MalFragmentBase
    {
        private PopularVideosViewModel ViewModel;

        private static readonly StyleSpan PrefixStyle;
        private static readonly ForegroundColorSpan PrefixColorStyle;

        static PromoVideosPageFragment()
        {
            PrefixStyle = new StyleSpan(TypefaceStyle.Bold);
            PrefixColorStyle = new ForegroundColorSpan(new Color(ResourceExtension.AccentColour));
        }

        private GridViewColumnHelper _helper;

        protected override void Init(Bundle savedInstanceState)
        {
            ViewModel = ViewModelLocator.PopularVideos;
            ViewModel.Init();
        }




        protected override void InitBindings()
        {
            Bindings.Add(
                this.SetBinding(() => ViewModel.Loading,
                    () => PromoVideosPageLoadingSpinner.Visibility).ConvertSourceToTarget(Converters.BoolToVisibility));

            _helper = new GridViewColumnHelper(PromoVideosPageGridView);

            Bindings.Add(this.SetBinding(() => ViewModel.Videos).WhenSourceChanges(() =>
            {
                if (ViewModel.Videos != null)
                    PromoVideosPageGridView.InjectFlingAdapter(ViewModel.Videos.ToList(), SetItemBindingsFull,
                        SetItemBindingsFling, GetItemContainer);
                else
                    PromoVideosPageGridView.Adapter = null;
            }));          
        }

        private View GetItemContainer()
        {
            var view = Activity.LayoutInflater.Inflate(Resource.Layout.PromoVideosPageItem, null);

            view.FindViewById(Resource.Id.PromoVideosPageItemImageSection).Click += VideoItemOnClickOpenVideo;
            view.FindViewById(Resource.Id.PromoVideosPageItemSubtitleSection).Click += VideoItemOnClickOpenAnime;

            return view;
        }

        private void SetItemBindingsFull(View view,AnimeVideoData animeVideoData)
        {
            Log.Debug("lol", "full");
            var img = view.FindViewById<ImageViewAsync>(Resource.Id.PromoVideosPageItemImage);
            if ((string)img.Tag != animeVideoData.YtLink)
            {
                view.FindViewById(Resource.Id.PromoVideosPageItemImgPlaceholder).Visibility = ViewStates.Gone;
                img.Tag = animeVideoData.YtLink;
                img.Into(animeVideoData.Thumb);
            }

            var str = new SpannableString($"{animeVideoData.Name} - {animeVideoData.AnimeTitle}");
            str.SetSpan(PrefixStyle, 0, animeVideoData.Name.Length, SpanTypes.InclusiveInclusive);
            str.SetSpan(PrefixColorStyle, 0, animeVideoData.Name.Length, SpanTypes.InclusiveInclusive);
            view.FindViewById<TextView>(Resource.Id.PromoVideosPageItemSubtitle)
                .SetText(str.SubSequenceFormatted(0, str.Length()), TextView.BufferType.Spannable);
        }

        private void SetItemBindingsFling(View view,AnimeVideoData animeVideoData)
        {
            Log.Debug("lol", "fling");
            view.FindViewById(Resource.Id.PromoVideosPageItemImgPlaceholder).Visibility = ViewStates.Visible;
            view.FindViewById(Resource.Id.PromoVideosPageItemImage).Visibility = ViewStates.Invisible;

            var str = new SpannableString($"{animeVideoData.Name} - {animeVideoData.AnimeTitle}");
            str.SetSpan(PrefixStyle, 0, animeVideoData.Name.Length, SpanTypes.InclusiveInclusive);
            str.SetSpan(PrefixColorStyle, 0, animeVideoData.Name.Length, SpanTypes.InclusiveInclusive);
            view.FindViewById<TextView>(Resource.Id.PromoVideosPageItemSubtitle)
                .SetText(str.SubSequenceFormatted(0, str.Length()), TextView.BufferType.Spannable);
        }

        private async void VideoItemOnClickOpenVideo(object sender, EventArgs eventArgs)
        {
            await AnimeDetailsPageViewModel.OpenVideo(((sender as View).Parent as View).Tag.Unwrap<AnimeVideoData>());
        }

        private void VideoItemOnClickOpenAnime(object sender, EventArgs eventArgs)
        {
            ViewModel.NavDetailsCommand.Execute(((sender as View).Parent as View).Tag.Unwrap<AnimeVideoData>());
        }

        public override int LayoutResourceId => Resource.Layout.PromoVideosPage;

        protected override void Cleanup()
        {
            PromoVideosPageGridView.ClearFlingAdapter();
            base.Cleanup();
        }

        #region Views

        private GridView _promoVideosPageGridView;
        private ProgressBar _promoVideosPageLoadingSpinner;
        private bool _isFlingActive;

        public GridView PromoVideosPageGridView => _promoVideosPageGridView ?? (_promoVideosPageGridView = FindViewById<GridView>(Resource.Id.PromoVideosPageGridView));

        public ProgressBar PromoVideosPageLoadingSpinner => _promoVideosPageLoadingSpinner ?? (_promoVideosPageLoadingSpinner = FindViewById<ProgressBar>(Resource.Id.PromoVideosPageLoadingSpinner));

        #endregion
    }
}