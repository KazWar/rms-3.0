<script lang="ts">
  export default {
    name: 'datepicker'
  }
</script>

<script setup lang=ts>

const { label, icon, mask, name } = defineProps<{
    name:string
    label:string
    icon?:string | undefined
    mask?: string | undefined
}>()

/**
 * Create a default value ref
 */
const value = $ref('')

/**
 * Define an emit for updating the v-model in the parent
 */
const emit = defineEmits(['update:modelValue'])

//! Remove later
/**
 * Create a function to take in the new value and emit it
 * 
 * @param value new model value
 */
function emitInput(value: number | Date | string): void {
    emit('update:modelValue', value)
}

const required = (value: any): string | boolean => {
    return (value === '' || value === null || value.length < 1) ? '' : true
}
</script>

<template>
    <div class="q-px-xs">
        <div class="row">
            <div class="col">
                <q-time
                    :ref="name"
                    v-model="value"
                    type="date"
                    format24h   
                    :label="label"
                    :rules="[required]"
                    :mask="mask"
                    @update:model-value="(value:any) => { emitInput(value) }"
                >
                    <template>
                        <tool-tip :icon="icon" text="hello"/>
                    </template>
                </q-time>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <q-date
                    :ref="name"
                    v-model="value"
                    type="date"
                    :label="label"
                    :rules="[required]"
                    :mask="mask"
                    @update:model-value="(value:any) => { emitInput(value) }"
                >
                    <template>
                        <tool-tip :icon="icon" text="hello"/>
                    </template>
                </q-date>
            </div>
        </div>
    </div>

    <div class="q-px-xss">
        <div class="row">
            <div class="col">
                <q-input
                    :ref="name"
                    v-model="value"
                    type="date"
                    :label="label"
                    :rules="[required]"
                    :mask="mask"
                    @update:model-value="(value:any) => { emitInput(value) }"
                >
                    <template>
                        <tool-tip :icon="icon" text="hello"/>
                    </template>
                </q-input>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
    .q-px-xs{
        display: flex;

        .row{
            width: 300px;
            margin-left: 35px;
        }
    }

    .q-px-xss{
        margin-top: 30px;
    }
</style>