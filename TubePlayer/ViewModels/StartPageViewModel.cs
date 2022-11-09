using Maui.Apps.Framework.Exceptions;

namespace TubePlayer.ViewModels
{
    public class StartPageViewModel : AppViewModelBase
    {
        public StartPageViewModel(IApiService appApiService) : base(appApiService)
        {
            this.Title = "TUBE PLAYER";
        }

        public override async void OnNavigatedTo(object parameters)
        {
            SetDataLoadingIndicators(true);

            LoadingText = "Hold on, we are loading";

            try
            {
                await Task.Delay(3000);

                throw new Exception("Unable to reach Google Youtube API Service");

                this.DataLoaded = true;
            }
            catch(InternetConnectionException iex)
            {
                this.IsErrorState = true;
                this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check your internet connection and try again. ";
                ErrorImage = "nointernet.png";
            }
            catch (Exception ex)
            {
                this.IsErrorState = true;
                this.ErrorMessage = $"Something went wrong. If the problem persists, please contact support at {Constants.EmailAddress} with the error message:" + Environment.NewLine + Environment.NewLine + ex.Message;
                ErrorImage = "error.png";
            }
            finally
            {
                SetDataLoadingIndicators(false);
            }
        }
    }
}
