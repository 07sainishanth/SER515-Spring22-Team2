import env
import sensors
import pygame
import math

environ = env.buildEnv((600, 1200))
environ.originalMap = environ.map.copy()
laser = sensors.laserSensor(200, environ.originalMap, uncert=(0.5, 0.01))
environ.map.fill((0, 0, 0))

environ.infomap = environ.map.copy()
runn = True



while runn:
	senseOn = False
	for event in pygame.event.get():
		if event.type == pygame.QUIT:
			runn = False

		if pygame.mouse.get_focused():
			senseOn = True
		elif not pygame.mouse.get_focused():
			senseOn = False

	if senseOn:
		posit = pygame.mouse.get_pos()
		laser.posit = posit
		sensor_dat = laser.sense_obstac()
		environ.dataStorage(sensor_dat)
		environ.show_sensorData()

	environ.map.blit(environ.infomap, (0,0))


	pygame.display.update()