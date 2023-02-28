<script setup lang=ts>
import { Field } from '@/common/models'
import { FormKitFrameworkContext } from '@formkit/core'
import {ref} from 'vue'

let { context } = defineProps<{
    context: FormKitFrameworkContext
}>()

const { 
    name, type, tooltip,
    design, linkId, features,
    label, rules, mask, options,
    custom
 } = context.field as Field

/**
 * Create a default value ref
 */
const value = $ref(null)
const validate = (value:any) => {
    console.log(value)
    context.node.input(value)
}

const selection = ref(5)

const model = ref({
    min: 1, max: 5
})

const modell = ref({
    min: 1, max: 5
})

</script>




<template>
    <div class="q-px-xss">
        <div class="row">
            <div class="col">
               <q-slider
                    v-bind="{
                        ...(features as object),
                        ...(mask as object),
                        ...(design as object),
                        ...(custom as object)
                    }"
                    v-model="selection"
                    :inner-max="45"
                    :inner-min="-15"
                    :min="-20"
                    :max="50"
                    :step="5"
                    snap 
                    color="teal"
                    track-size="8px"
                    track-color="red"
                    inner-track-color="red" 
                    selection-color="blue"
                    label-text-color="white"
                    :label-value="selection"
                    label
                    label-always
                    :rules="rules"
                    @update:model-value="(value) => { validate(value) }"
                />

                <h5> {{selection}} </h5>

                <q-range
                    v-model="model"
                    :min="0"
                    :max="10"
                    color="green"
                    track-size="10px"
                    thumb-color="black"
                    markers
                />
                <h5> {{model}} </h5>

                <q-range
                    v-model="model"
                    :min="0"
                    :max="10"
                    color="green"
                    thumb-size="35px"
                    markers
                />
                <h5> {{modell}} </h5>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
</style>


