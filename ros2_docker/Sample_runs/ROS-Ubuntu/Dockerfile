# adapted from: https://github.com/Tiryoh/docker-ros2-desktop-vnc

FROM ubuntu:latest as base
MAINTAINER Sai Nishanth Vaka <vsainishanth@gmail.com>


# Setting up ubuntu environment

RUN apt-get update -qq \
  && apt-get -y install locales \
  && locale-gen en_US en_US.UTF-8 \
  && update-locale LC_ALL=en_US.UTF-8 LANG=en_US.UTF-8 \
  && export LANG=en_US.UTF-8



RUN apt-get update -qq \
  && DEBIAN_FRONTEND=noninteractive apt-get -y install curl gnupg2 lsb-release tzdata htop tmux

# Setting up ROS2 repostories in system

RUN curl -s https://raw.githubusercontent.com/ros/rosdistro/master/ros.asc | apt-key add - \
  && sh -c 'echo "deb [arch=amd64,arm64] http://packages.ros.org/ros2/ubuntu `lsb_release -cs` main" > /etc/apt/sources.list.d/ros2-latest.list' \
  && apt-get update -qq \
  && apt-get -y install ros-dashing-ros-base \
  && apt-get autoclean && apt-get clean && apt-get -y autoremove \
  && rm -rf /var/lib/apt/lists/*

# Installing ROS2

FROM base AS desktop

RUN apt-get update -qq \
  && apt-get -y install --no-install-recommends ros-dashing-desktop \
  && apt-get autoclean && apt-get clean && apt-get -y autoremove \
  && rm -rf /var/lib/apt/lists/*
