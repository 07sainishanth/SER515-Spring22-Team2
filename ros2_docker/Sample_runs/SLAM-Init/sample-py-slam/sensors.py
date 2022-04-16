import pygame
import math
import numpy as np

def uncert_add(distance, angle, sigma):
	mean = np.array([distance, angle])
	covariance = np.diag(sigma ** 2)
	distance, angle = np.random.multivariate_normal(mean, covariance)
	distance = max(distance, 0)
	angle = max(angle, 0)
	return [distance, angle]


class laserSensor(object):
	"""docstring for laserSensor"""
	def __init__(self, range_, map_, uncert):
		super(laserSensor, self).__init__()
		self.range = range_
		self.map = map_
		self.uncert = uncert
		self.speed = 4
		self.sigma = np.array([uncert[0], uncert[1]])
		self.posit = (0, 0)
		self.width, self.height = pygame.display.get_surface().get_size()
		self.sensedObstac = []


	def distance(self, obstacPosit):
		px = (obstacPosit[0] - self.posit[0])**2
		py = (obstacPosit[1] - self.posit[1])**2
		return math.sqrt(px+py)


	def sense_obstac(self):
		data  = []
		x1, y1 = self.posit[0], self.posit[1]
		for angle in np.linspace(0, 2*math.pi,60, False):
			x2, y2 = (x1+self.range*math.cos(angle), y1-self.range*math.sin(angle))

			for i in range(0, 100):
				u = i/100
				x  = int(x2 * u + x1 * (1-u))
				y  = int(y2 * u + y1 * (1-u))

				if 0 < x <self.width and 0 < y < self.height:
					color = self.map.get_at((x,y))

					if(color[0], color[1], color[2]) == (0, 0, 0):

						distance_ = self.distance((x, y))
						output = uncert_add(distance_, angle, self.sigma)
						output.append(self.posit)

						data.append(output)

						break

			if len(data) > 0:
				return data

			else :
				return False

