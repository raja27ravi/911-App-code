# 911-App-code
911-demo

---For setting up environement we need :
Anaconda Distrubution

channels:
- !!python/unicode
  'defaults'
dependencies:
- python=3.5
- pip==9.0.1
- numpy==1.12.0
- jupyter==1.0
- matplotlib==2.0.0
- scikit-learn==0.18.1
- scipy==0.19.0
- pandas==0.19.2
- pillow==4.0.0
- seaborn==0.7.1
- h5py==2.7.0
- pip:
  - tensorflow==1.1.0
  - keras==2.0.4

  
 The above are the dependencies for running our code
 
 For building phone app
Install the latest version of npm package and phone gap for performing the build using online platform phonegap.
after installing we go to project directory and run the code using :

phonegap serve


For visulisation we used seaborn and tableau online and desktop version.
we got the data from google cloud sql which was the output for pyspark job that was run in google cloud.

we can use 911_nan_zip_dataset.csv for our data learning model.

for using pysparksql we have to import sparksession

The machine learning part of this application was inspired and ideas were taken from 

https://github.com/lukaszkm/machinelearningexp/blob/master/Machine_Learning_Regression_911Calls.ipynb
