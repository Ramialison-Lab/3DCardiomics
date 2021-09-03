# 3D-Cardiomics
## A visual system for the exploration of cardiac transcriptome data


### Overview
3D-Cardiomics provides a framework to map multi dimensional data (such as intensity and location of gene expression) on to 3D models in a heatmap-like manner. In our use case the intensity is the level of gene expression of those expressed in the adult heart, and the location is this expression level in 18 discrete pieces of the heart as measured by RNA-seq.

3D-cardiomics-VR for [VR devices](https://github.com/Ramialison-Lab/3DCardiomicsVR) such as Oculus Quest or Rift and for [zSpace](https://github.com/Ramialison-Lab/3DCardiomicszSpace) are available as well.

### Dependencies
- Unity (we are using 2018.4.23.f1)
- Any modern web browser which is WebGL capable

### <a name="instructions"> Instructions </a>
Simply run unity and open the root folder of the project. If the heart scene is not visible, open it in unity by browsing to and double clicking the following file:
```
Assets/3DCardiomics_main.unity
```

### Upload expression values

3D-cardiomics supports to render user provided expression values on our 3D-cardiomics model on your local machine. Therefore, please follow the **[Instructions](#instructions)** to run 3D-Cardiomics on your local machine.

To expression values are stored in:

```
Assets/Ressources/...
```

You can simply add new files by navigating to the **Ressources** folder (blue box) and using left-click to choose **Import New Asset...*. 

![NewAsset](https://user-images.githubusercontent.com/79250095/131953413-d93d5426-935f-4c87-8614-84ab0a24f410.png)

Search the file to upload on your local computer and select it. To set this file as expression values click on the **ScriptHolder** Object (red box) on the left side.
![SH](https://user-images.githubusercontent.com/79250095/131953566-875f65eb-f81a-4569-8d65-17b17dd7f238.png)

This will open the **Inspector** Tab on the right side. Enter the name of the file you just uploaded into the input field **Csv Filename Base** (red box). (Without file ending such as .txt or .csv).

![fileName](https://user-images.githubusercontent.com/79250095/131953677-905716d8-6577-445b-bdf8-bf2eb1f6dcc5.png)

If you run the application now by pressing the Start button, your expression values will be available to display onto the 3D model.

Please keep in mind, that in order to use your expression values, the data has to be in a specific format. Currently supported are only CSV files, either in .csv or .txt format. 
Each row has to begin with the item's name and its intensity in the 18 locations. A sample file (fake_mouse_expression_values) is provided with a few randomised values to demonstrate the functionality.

The application only supports visualisation of raw data [A] for intensity if they are within a range from -3 to 20. The application will disable the raw view if values outside the boundaries are detected (Normalized expressions can still be viewed).

