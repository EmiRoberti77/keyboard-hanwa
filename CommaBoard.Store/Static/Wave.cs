using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommaBoard.Store.Class;
using MvvmCross.ViewModels;

namespace CommaBoard.Store.Static
{
    public static class Wave
    {

        static ViewingGrid grid = new ViewingGrid();

        public static ViewingGrid Grid
        {
            get
            {
                return grid;
            }
            set
            {
                grid = value;
            }
        }

        public static List<LayoutItem> SavedLayoutItems { get; set; }

        public static int[] LayoutNumArray = new int[3] { 1, 4, 9 };

        /// <summary>
        /// Find the previous or next Selected Layout logical Id
        /// </summary>
        /// <param name="prev">Whether Prev or Next button has been pressed</param>
        /// <returns></returns>
        public static int ChangeSelectedLayoutLogicalId(bool prev)
        {

            //  Create a temporary list to handle the sorting etc
            List<Layout> tempList = Wave.Grid.LayoutControlLayoutList.OrderBy(l => l.logicalId).ToList();

            //  Now find the current index of the current logical id
            int currentIndex = tempList.FindIndex(l => l.logicalId == Wave.Grid.CurrentLayoutLogicalId);

            //  If currentIndex = -1 something has gone wrong so bail out
            if (currentIndex == -1) return 0;

            if (prev)
            {
                //  Previous so ensure we are not already at index 0
                if (currentIndex == 0) return tempList.Last().logicalId;

                //  Not already at index 0 so go to Layout at previous index
                currentIndex--;
              
                return tempList[currentIndex].logicalId;
            }

            //  Next so ensure we are not at the last index already
            if (currentIndex == tempList.Count - 1) return tempList.First().logicalId;

            //  Not the last so go to Layout at the next index
            currentIndex++;
            
            return tempList[currentIndex].logicalId;

        }

    }

    public class ViewingGrid : MvxNotifyPropertyChanged
    {

        #region     Camera Control

        MvxObservableCollection<Camera> _cameraControlCameraList;
        public MvxObservableCollection<Camera> CameraControlCameraList
        {
            get { return _cameraControlCameraList; }

            set { SetProperty(ref _cameraControlCameraList, value); }
        }

        Camera _cameraControlSelectedCamera;
        public Camera CameraControlSelectedCamera
        {
            get { return _cameraControlSelectedCamera; }

            set { SetProperty(ref _cameraControlSelectedCamera, value); }
        }


        #endregion

        #region     Layout Control

        int _currentLayoutLogicalId;
        public int CurrentLayoutLogicalId
        {
            get { return _currentLayoutLogicalId; }

            set { SetProperty(ref _currentLayoutLogicalId, value); }
        }

        int _currentCameraLogicalId;
        public int CurrentCameraLogicalId
        {
            get { return _currentCameraLogicalId; }

            set { SetProperty(ref _currentCameraLogicalId, value); }
        }

        MvxObservableCollection<Layout> _layoutControlLayoutList;
        public MvxObservableCollection<Layout> LayoutControlLayoutList
        {
            get { return _layoutControlLayoutList; }

            set
            {
                SetProperty(ref _layoutControlLayoutList, value);

                UpdateSelectedLayout();
            }
        }

        Layout _layoutControlSelectedLayout;
        public Layout LayoutControlSelectedLayout
        {
            get { return _layoutControlSelectedLayout; }

            set
            {
                SetProperty(ref _layoutControlSelectedLayout, value);

                //  Change the Selected Layout Cameras
                LoadSelectedLayoutCameraList();

            }
        }

        MvxObservableCollection<Camera> _layoutControlCameraList;
        public MvxObservableCollection<Camera> LayoutControlCameraList
        {
            get { return _layoutControlCameraList; }

            set 
            { 
                SetProperty(ref _layoutControlCameraList, value);

                //  Update the selected Camera
                UpdateSelectedCamera();
            }
        }

        Camera _layoutControlSelectedCamera;
        public Camera LayoutControlSelectedCamera
        {
            get { return _layoutControlSelectedCamera; }

            set
            {
                SetProperty(ref _layoutControlSelectedCamera, value);

                if (_layoutControlSelectedCamera != null)
                    Display.Numbers.NumberDisplayCamera = _layoutControlSelectedCamera.logicalId == "" ? 0 : int.Parse(_layoutControlSelectedCamera.logicalId);
            }
        }  

        #endregion

        #region     Public Methods

        public void UpdateSelectedLayout()
        {
            //  If there are no Layouts bail out here
            if (Wave.Grid.LayoutControlLayoutList.Count == 0) return;

            //  We have at least one Layout in the list
            //  If the current id is zero then find the first layout
            if (Wave.Grid.CurrentCameraLogicalId == 0)
            {
                Wave.Grid.LayoutControlSelectedLayout = Wave.Grid.LayoutControlLayoutList.FirstOrDefault();

                Wave.Grid.CurrentLayoutLogicalId = Wave.Grid.LayoutControlSelectedLayout.logicalId;

                return;
            }

            //  We have a current Layout ( logical Id > 0 )
            Wave.Grid.LayoutControlSelectedLayout = Wave.Grid.LayoutControlLayoutList.Where(l => l.logicalId == Wave.Grid.CurrentLayoutLogicalId).FirstOrDefault();

            //  If there is an error an no selected layout choose the first one again
            if (Wave.Grid.LayoutControlSelectedLayout == null)
            {
                Wave.Grid.LayoutControlSelectedLayout = Wave.Grid.LayoutControlLayoutList.FirstOrDefault();

                Wave.Grid.CurrentLayoutLogicalId = Wave.Grid.LayoutControlSelectedLayout.logicalId;

            }

        }

        public void LoadSelectedLayoutCameraList()
        {
            //  Initialise Selected Layout camera list
            LayoutControlCameraList = new MvxObservableCollection<Camera>();
            MvxObservableCollection<Camera> temp = new MvxObservableCollection<Camera>();

            //  No point going further if no items in the Selected Layout
            if (LayoutControlSelectedLayout == null || LayoutControlSelectedLayout.items == null || LayoutControlSelectedLayout.items.Length == 0)
            {
                return;
            }

            //  Iterate through the Selected Layout items to find the cameras
            foreach (var li in LayoutControlSelectedLayout.items)
            {
                //  Find the resource id and use it to find the eqivelent camera id
                Guid guid = li.resourceId;
                Camera cam = CameraControlCameraList.Where(c => c.id == guid).FirstOrDefault();

                //  If a camera has been found then add it to the Selected Layout Camera List
                if (cam != null)
                    temp.Add(cam);
            }

            LayoutControlCameraList = temp;

        }

        public void UpdateSelectedCamera()
        {
            //  No point going further if no Cameras in the Selected Layout camera list
            if (Wave.Grid.LayoutControlCameraList == null || Wave.Grid.LayoutControlCameraList.Count == 0)
            {
                return;
            }

            //  We have at least one Camera in the Selected Camera list
            //  If the current id is zero then find the first Camera and reset the logical Id
            if (Wave.Grid.CurrentCameraLogicalId == 0)
            {
                Wave.Grid.LayoutControlSelectedCamera = Wave.Grid.LayoutControlCameraList.FirstOrDefault();

                Wave.Grid.CurrentCameraLogicalId = int.Parse(Wave.Grid.LayoutControlSelectedCamera.logicalId);

                return;
            }

            //  We have a current Camera ( logical Id > 0 )
            Wave.Grid.LayoutControlSelectedCamera = Wave.Grid.LayoutControlCameraList.Where(c => c.logicalId == Wave.Grid.CurrentCameraLogicalId.ToString()).FirstOrDefault();

            //  If there is an error and no selected Camera then choose the first one again
            if (Wave.Grid.LayoutControlSelectedCamera == null)
                Wave.Grid.LayoutControlSelectedCamera = Wave.Grid.LayoutControlCameraList.FirstOrDefault();

            Wave.Grid.CurrentCameraLogicalId = int.Parse(Wave.Grid.LayoutControlSelectedCamera.logicalId);


        }

        #endregion

    }
}
