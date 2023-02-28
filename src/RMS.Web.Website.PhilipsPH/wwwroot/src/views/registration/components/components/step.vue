<script setup lang="ts">
//* External Libraries
import { createInput } from "@formkit/vue"
import { Bundle, Field } from "@/common"

//* Components
import textField from './components/text-field.vue'
import textFieldConfirm from './components/text-field-confirm.vue'
import datepicker from './components/date-picker.vue'
import dropDown from './components/dropdown.vue'
import FileUploader from './components/File-picker.vue'
import GroupOption from './components/group-option.vue'
import Slider from './components/slider.vue'
import Paragraphfield from './components/paragraph-field.vue'

const props = defineProps<{
  name: number,
  title: string,
  bundles: Bundle[]
}>()

let { name, title, bundles } = props

//! Should probably become a helper function
let component:any = (name:string) => {
  //! Place it in a store
  const components:Record<string,object> = {
    "datepicker": datepicker,
    "input":  textField,
    "dropdown": dropDown,
    "fileuploader": FileUploader,
    "groupoption": GroupOption,
    "slider": Slider,
    "paragraphfield": Paragraphfield,
    "textfieldconfirm": textFieldConfirm
  }

  return createInput(components[name], { props: ['field']})
}

const disabled = $ref(true)

const confirm = createInput(textFieldConfirm, { props: ['field','disabled']})

</script>

<template>
  <q-step
    :name="name"
    :title="title"
  >
    <form-kit type="group">
      <!-- Loop over all the bundles in a section -->
      <template v-for="bundle in bundles" :key="bundle.name">
        <!-- Loop over all the fields in a bundle -->
        <template v-for="field in bundle.fields" :key="field.name">
            <!-- If link id is empty, just render the component -->
            <form-kit 
              v-if="!field.linkId" 
              :name="field.name"
              :type='component(field.type.name)' 
              :field="new Field(field)"
            />

            <!-- Otherwise a link ID must be present.  -->
            <!-- Render the initial component and then linked component after. -->
            <template v-else>
              <form-kit :name="field.name" :type='component(field.type.name)' :field="new Field(field)" @update:model-value="disabled = false"/>
              <form-kit :name="field.name + 'Confirm'" :type='confirm' :field="new Field(field)" :disabled="disabled"/>
            </template>
        </template>
      </template>
    </form-kit>
  </q-step>
</template>

<style scoped lang="scss">

</style>