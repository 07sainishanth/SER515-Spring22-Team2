import math
import pygame

class buildEnv(object):
	"""docstring for buildEnv"""
	def __init__(self, mapDim):
		super(buildEnv, self).__init__()
		# self.arg = arg
		pygame.init()
		self.pointCloud = []
		self.extMap = pygame.image.load("map1.png")
		self.maph, self.mapw  = mapDim
		self.mapWind_ = 'RRT path planning'
		pygame.display.set_caption(self.mapWind_)
		self.map = pygame.display.set_mode((self.mapw, self.maph))
		self.map.blit(self.extMap,(0,0))
		self.black = (0, 0, 0,)
		self.grey = (70, 70, 70)
		self.red = (255, 0, 0)
		self.blue = (0, 0, 255)
		self.green = (0, 255, 0)
		self.white = (255, 255, 255)


	def ad2Pos(self, distance, angle, robPosit):
		x = distance * math.cos(angle)+robPosit[0]
		y = distance * math.sin(angle)+robPosit[1]
		return (int(x), int(y))

	def dataStorage(self, data):
		print(len(self.pointCloud))

		if not data:
			return

		for ele in data:

			point = self.ad2Pos(ele[0], ele[1], ele[2])

			if point not in self.pointCloud:

				self.pointCloud.append(point)

	def show_sensorData(self):

		self.infomap = self.map.copy()

		for point in self.pointCloud:
			self.infomap.set_at((int(point[0]), int(point[1])), (255, 0, 0))


		