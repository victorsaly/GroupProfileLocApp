<template>
  <div>
    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input v-model="profile.fullName" type="text" placeholder="Full Name" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="FullName">
          Full Name
        </label>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input v-model="profile.email" type="email" placeholder="Email" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="Email">
          Email
        </label>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input v-model="profile.password" type="password" placeholder="Password" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="Password">
          Password
        </label>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm label-floating">
        <input v-model="profile.city" type="text" placeholder="City" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
        <label class="hidden" for="City">
          City
        </label>
      </div>
    </div>

    <div class="relative inline-block text-left w-full mb-2">
      <div class="shadow-sm">
        <div class="flex flex-row label-floating">
          <input v-model="profile.country" type="text" placeholder="Country" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150">
          <label class="hidden" for="Country">
            Country
          </label>
          <button type="submit" class="group relative w-20 flex-1 justify-center px-3 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-gray-800 hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-indigo active:bg-gray-700 transition duration-150 ease-in-out" @click="getCurrentPersonLocation">
            <svg class="h-10 w-8 fill-current mx-auto" viewBox="0 0 24 24">
              <path class="heroicon-ui" d="M5.64 16.36a9 9 0 1 1 12.72 0l-5.65 5.66a1 1 0 0 1-1.42 0l-5.65-5.66zm11.31-1.41a7 7 0 1 0-9.9 0L12 19.9l4.95-4.95zM12 14a4 4 0 1 1 0-8 4 4 0 0 1 0 8zm0-2a2 2 0 1 0 0-4 2 2 0 0 0 0 4z" />
            </svg>
          </button>
        </div>
      </div>
    </div>
    <VuePhoneNumberInput
      id="phoneNumber1"
      v-model="profile.phoneNumber"
      class="mb-2"
      clearable
      :default-country-code="defaultCountryCode"
    />

    <div class="flex relative inline-block text-left w-full mb-2">
      <div class="shadow-sm w-full label-floating">
        <input v-model="profile.instagramProfile" type="text" placeholder="Instagram profile" class="flex w-full border border-gray-300 px-6 py-4 bg-white text-sm leading-5 font-medium text-gray-700 hover:text-gray-500 focus:outline-none focus:border-blue-300 focus:shadow-outline-blue active:bg-gray-50 active:text-gray-800 transition ease-in-out duration-150" @keyup="geInstagramImage">
        <label class="hidden" for="InstagramProfile">
          Instagram Profile
        </label>
      </div>
      <div v-if="instagramImageUrl" class="flex items-center justify-center border border-gray-300 ml-1 px-1" style="width: 58px;">
        <img :src="instagramImageUrl" alt="instagram-profile">
      </div>
    </div>

    <button type="submit" class="group relative w-full flex justify-center my-8 py-4 px-6 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-gray-800 hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-indigo active:bg-gray-700 transition duration-150 ease-in-out" @click="onSaveProfileClick">
      SAVE PROFILE
    </button>
  </div>
</template>
<script>

import VuePhoneNumberInput from 'vue-phone-number-input'
import 'vue-phone-number-input/dist/vue-phone-number-input.css'
import axios from 'axios'
import gql from 'graphql-tag'

const getImage = gql`
  query getPersonProfileImage($url: String!) {
    openGraphManager_GetOpenGraph(url: $url){
      title
      image
  }
}`

export default {
  components: { VuePhoneNumberInput },
  data () {
    return {
      profile: {
        fullName: null,
        email: null,
        country: null,
        phoneNumber: null,
        password: null,
        instagramProfile: null
      },
      instagramImageUrl: null,
      defaultCountryCode: null
    }
  },
  mounted () {
    this.getCurrentPersonLocation()
  },
  methods: {
    geInstagramImage () {
      // todo: add debounce
      this.$apollo.query({ query: getImage, variables: { url: `http://instagram.com/${this.profile.instagramProfile}` } })
        .then((res) => {
          this.instagramImageUrl = res.data.openGraphManager_GetOpenGraph.image
        })
        .catch(console.error)
    },
    getCurrentPersonLocation () {
      axios.get('https://ip2c.org/s')
        .then(({ data }) => {
          const [, countryCode,, countryName] = data.split(';')
          this.defaultCountryCode = countryCode
          this.profile.country = countryName
        })
        .catch(console.error)
    },
    onSaveProfileClick () {
      console.log('onSaveProfileClick')
    }
  }
}
</script>
