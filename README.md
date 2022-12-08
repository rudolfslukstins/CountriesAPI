<h1 align="center">
  <br>
  <img src="https://28stone.com/images/28stone-logo-dark.svg" alt="28Stone" width="200"></a>
</h1>


# CountriesAPI
This is a technical task for a company SIA "28Stone". Project contains an WebAPI application that consumes data from API and returns requested data for Oceania region countries.

### Description:

* Built on .NET6 framework
* Consumes data from [REST API](https://restcountries.com/)
* Added logging 
* Added unit tests
 <details>
  <summary>Additional packages you will needed to run this project</summary>
  
  * Additional packages for WebProject
  
  ![image](https://user-images.githubusercontent.com/108486650/206156199-f6c73a7e-8c48-4ae3-a771-09c05e0c4aaf.png)
      
  * Additional packages for Testing 
      
      ![image](https://user-images.githubusercontent.com/108486650/206157791-3c42b745-b89b-4445-91a0-962828af2536.png)
      ![image](https://user-images.githubusercontent.com/108486650/206157921-988c9b9d-4d95-40b6-9e00-80c878fbdec8.png)
  
</details>

### How to run project:
  
  1.Fork this repository and clone it on your computer or download it as a .zip file and unarchive it.
  
  ![image](https://user-images.githubusercontent.com/108486650/206163226-b5c4fd51-b5a4-4f0c-8e24-b5bca83ccfdf.png)
  
  2. Open project in your file explorer and open CountriesAPI and click on `CountriesAPI.sln`
  3. If the packages are installed you are ready to run project. Click `Run Project` and Swagger page should open with three endpoints:
  
  ![ezgif com-gif-maker (3)](https://user-images.githubusercontent.com/108486650/206165712-aad2556c-830f-4c6b-8018-69e4b6c93911.gif)

  4. 
  * The first endpoint returns the Top 10 countries with the biggest population.
  * The second endpoint returns the Top 10 countries with the biggest population density.
  * The third endpoint returns a specific country except the country name you have passed in. If that country isn't from Oceania endpoint shouldn't find it.
 
![ezgif com-gif-maker (5)](https://user-images.githubusercontent.com/108486650/206171079-91801a6c-ecc8-4c15-b165-7b6758475b9c.gif)


### How to run tests: 

![ezgif com-gif-maker (6)](https://user-images.githubusercontent.com/108486650/206425334-74e6333e-be82-4856-9baa-d54dbda391d9.gif)

    
