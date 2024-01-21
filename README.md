# SIMULATOR VOŽNJE

**Potreban Unity editor version: 2021.3.30f1**


## Kratke upute za otvaranje projekta u Unityju:
1. stvoriti novi folder u File exploreru
1. otvoriti terminal i pozicionirati se u novostvorenom folderu
1. upisati:
``` git clone https://github.com/kristina-cavlovic/ISS_tim11.git ```
1. upisati: ``` cd ISS_tim11 ```
1. upisati: ``` git checkout master ```


### U Unityju Hubu:
1. otići na Add (gornji desni ugao)
1. upisati putanju gornjeg foldera i stisnuti "Otvori"


## Unutar otvorenog projekta u Unityju:
- scena je pohranjena u: ``` Assets\Scenes\SyntyStudios\PolygonCity\Scenes ``` pod nazivom **Demo** (klikom na nju otvara se projekt)
- vozilo kojim se upravlja naziva se **SM_Veh_Car_Taxi_07**
- tekst datoteka u kojoj se bira početna pozicija auta (prije pokretanja game modea): ``` Assets\StreamingAssets\config.txt ```
    - sve moguće početne lokacije već se nalaze u .txt datoteci, samo se u prvi redak treba stavit željenu početnu lokaciju

# UPUTSTVA ZA KORIŠTENJE .exe DATOTEKE PROJEKTA 
1. unzippati issfinal.zip
1. projekt se pokreće otvaranjem datoteke New Unity Project.exe
1. promjena početne lokacije vrši se mijenjanjem config.txt datoteke (kao što je gore objašnjeno gore), no ovoga puta se config.txt nalazi na putanji ``` issfinal\New Unity Project_Data\StreamingAssets\config.txt ```

## Uputstva za upravljanje vozilom nakon pokretanja programa (ili u Unity game modeu):

### KRETANJE VOZILA:
- tipka C - gas
- tipka X - kočnica
- desna i lijeva strelica - skretanje
- tipka Space - ulazak u mod vožnje unatrag (treba ostati pritisnut na Space te istovremeno stisnuti gas)

### MIJENJANJE KUTA KAMERE:
- tipka 1 - pogled s vozačeve pozicije
- tipka 2 - pogled odozgora (3rd person view)
- tipka 3 - pogled iza auta
- tipka S - pogled na lijevi retrovizor (treba ostati pritisnut na tipku)
- tipka F - pogled na desni retrovizor (treba ostati pritisnut na tipku)




