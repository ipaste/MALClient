using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using MALClient.Android.BindingConverters;
using MALClient.Android.UserControls;
using MALClient.XShared.ViewModels;
using MALClient.XShared.ViewModels.Details;

namespace MALClient.Android.Fragments.AnimeDetailsPageTabs
{
    class AnimeDetailsPageCharactersTabFragment : MalFragmentBase
    {
        private AnimeDetailsPageViewModel ViewModel;
        private GridViewColumnHelper _gridHelper;

        protected override void Init(Bundle savedInstanceState)
        {
            ViewModel = ViewModelLocator.AnimeDetails;
        }

        protected override void InitBindings()
        {
            _gridHelper = new GridViewColumnHelper(AnimeDetailsPageCharactersTabGridView,340,1);
            Bindings.Add(this.SetBinding(() => ViewModel.AnimeStaffData).WhenSourceChanges(() =>
            {
                if (ViewModel.AnimeStaffData == null)
                    AnimeDetailsPageCharactersTabGridView.Adapter = null;
                else
                    AnimeDetailsPageCharactersTabGridView.InjectFlingAdapter(ViewModel.AnimeStaffData.AnimeCharacterPairs,DataTemplateFull,DataTemplateFling,ContainerTemplate  );
            }));

            Bindings.Add(
                this.SetBinding(() => ViewModel.LoadingCharactersVisibility,
                    () => AnimeDetailsPageCharactersTabLoadingSpinner.Visibility)
                    .ConvertSourceToTarget(Converters.BoolToVisibility));
        }

        private View ContainerTemplate()
        {
            var view =  Activity.LayoutInflater.Inflate(Resource.Layout.CharacterActorPairItem, null);
            return view;
        }

        private void DataTemplateFling(View view, AnimeDetailsPageViewModel.AnimeStaffDataViewModels.AnimeCharacterStaffModelViewModel models)
        {
            var itemCharacter = view.FindViewById<FavouriteItem>(Resource.Id.CharacterActorPairItemCharacter);
            var itemPerson = view.FindViewById<FavouriteItem>(Resource.Id.CharacterActorPairItemActor);

            itemCharacter.BindModel(models.AnimeCharacter, true);
            itemPerson.BindModel(models.AnimeStaffPerson, true);
        }

        private void DataTemplateFull(View view, AnimeDetailsPageViewModel.AnimeStaffDataViewModels.AnimeCharacterStaffModelViewModel models)
        {
            var itemCharacter = view.FindViewById<FavouriteItem>(Resource.Id.CharacterActorPairItemCharacter);
            var itemPerson = view.FindViewById<FavouriteItem>(Resource.Id.CharacterActorPairItemActor);

            itemCharacter.BindModel(models.AnimeCharacter,false);
            itemPerson.BindModel(models.AnimeStaffPerson,false);
        }

        public override int LayoutResourceId => Resource.Layout.AnimeDetailsPageCharactersTab;


        public override void OnConfigurationChanged(Configuration newConfig)
        {
            _gridHelper.OnConfigurationChanged(newConfig);
            base.OnConfigurationChanged(newConfig);
        }

        #region Views

        private GridView _animeDetailsPageCharactersTabGridView;
        private ProgressBar _animeDetailsPageCharactersTabLoadingSpinner;

        public GridView AnimeDetailsPageCharactersTabGridView => _animeDetailsPageCharactersTabGridView ?? (_animeDetailsPageCharactersTabGridView = FindViewById<GridView>(Resource.Id.AnimeDetailsPageCharactersTabGridView));

        public ProgressBar AnimeDetailsPageCharactersTabLoadingSpinner => _animeDetailsPageCharactersTabLoadingSpinner ?? (_animeDetailsPageCharactersTabLoadingSpinner = FindViewById<ProgressBar>(Resource.Id.AnimeDetailsPageCharactersTabLoadingSpinner));

        #endregion
    }
}