cd ~

python /home/acunha/UNET_R/20171106_train.py 0.0001   0 adam l -75 A_adam
python /home/acunha/UNET_R/20171106_train.py 0.00001   1 adam l -75 A_adam
python /home/acunha/UNET_R/20171106_train.py 0.000001   1 adam l -75 A_adam
python /home/acunha/UNET_R/20171106_train.py 0.0000001   1 adam l -75 A_adam


python /home/acunha/UNET_R/20171106_train.py 0.001   0 adam l -50 B_adam
python /home/acunha/UNET_R/20171106_train.py 0.0001   1 adam l -50 B_adam
python /home/acunha/UNET_R/20171106_train.py 0.00001   1 adam l -50 B_adam
python /home/acunha/UNET_R/20171106_train.py 0.000001   1 adam l -50 B_adam


python /home/acunha/UNET_R/20171106_train.py 0.001   0 adam l -50 C_adam
python /home/acunha/UNET_R/20171106_train.py 0.0001   1 adam l -50 C_adam
python /home/acunha/UNET_R/20171106_train.py 0.00001   1 adam l -50 C_adam
python /home/acunha/UNET_R/20171106_train.py 0.000001   1 adam l -50 C_adam


python /home/acunha/UNET_R/20171106_train.py 0.001   0 adam l -50 D_adam
python /home/acunha/UNET_R/20171106_train.py 0.0001   1 adam l -50 D_adam
python /home/acunha/UNET_R/20171106_train.py 0.00001   1 adam l -50 D_adam
python /home/acunha/UNET_R/20171106_train.py 0.000001   1 adam l -50 D_adam 

#Metrica:
# u.compile(optimizer=optim, loss=dice_coef_loss, metrics=[dice_coef,dice_coef_mean])