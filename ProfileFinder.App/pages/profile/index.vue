<template>
  <div>
    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <input type="text" placeholder="Full Name" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <input type="email" placeholder="Email" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <input type="password" placeholder="Password" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <input type="text" placeholder="City" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <div class="flex flex-row">
          <input type="text" placeholder="Country" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
          <button type="submit" class="group relative w-20 flex-1 justify-center px-3 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-gray-800 hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-indigo active:bg-gray-700 transition duration-150 ease-in-out" @click="onClickCurrent">
            <svg class="h-10 w-8 fill-current mx-auto" viewBox="0 0 24 24">
              <path class="heroicon-ui" d="M5.64 16.36a9 9 0 1 1 12.72 0l-5.65 5.66a1 1 0 0 1-1.42 0l-5.65-5.66zm11.31-1.41a7 7 0 1 0-9.9 0L12 19.9l4.95-4.95zM12 14a4 4 0 1 1 0-8 4 4 0 0 1 0 8zm0-2a2 2 0 1 0 0-4 2 2 0 0 0 0 4z" />
            </svg>
          </button>
        </div>
      </div>
    </div>
    <p>{{ currentLoc.coords }}</p>

    <button type="submit" class="group relative w-full flex justify-center py-4 px-6 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-gray-800 hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-indigo active:bg-gray-700 transition duration-150 ease-in-out">
      SAVE PROFILE
    </button>
  </div>
</template>
<script>
const ipp = require('instagram-profile-picture')
export default {
  data () {
    return {
      currentLoc: {},
      maplocation: { lng: 0, lat: 0 }
    }
  },
  methods: {
    async onClickCurrent () {
      ipp.small('9gag').then((user) => {
        console.log(user)
        // => https://scontent-sit4-1.cdninstagram.com/7...jpg
      })
      console.log('--onClickCurrent')
      try {
        const data = await getPosition()
        console.log('--success', data)
        console.log('typeof', typeof (data))

        const data2 = {}
        data2.lat = data.coords.latitude
        data2.lng = data.coords.longitude
        data2.alt = data.coords.altitude
        data2.accLatlng = data.coords.accuracy
        data2.accAlt = data.coords.altitudeAccuracy
        data2.heading = data.coords.heading // 0=北,90=東,180=南,270=西
        data2.speed = data.coords.speed

        // Object.assign(data2,data.coords); // not work
        // this.$set(this.currentLoc,"data2",data.coords);//not work
        console.log('data2', data2)
        this.$set(this.currentLoc, 'coords', data2)
        // https://geocode.xyz/51.6554752,-0.3833856?geoit=json
        // set Googlemap
        this.maplocation.lat = data2.lat
        this.maplocation.lng = data2.lng
        this.$refs.mmm.panTo(this.maplocation)
      } catch (e) {
        console.log('--error', e)
      }
    }
  }
}
const getPosition = function (options) {
  return new Promise(function (resolve, reject) {
    navigator.geolocation.getCurrentPosition(resolve, reject, options)
  })
}
</script>
